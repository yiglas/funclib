using System;
using System.Threading;
using static funclib.Util;

namespace funclib.Collections.Generic.Internal
{
    sealed class HashCollisionNode<TKey, TValue> :
        INode<TKey, TValue>
    {
        readonly int _hash;
        int _count;
        UnionType<TKey, TValue, INode<TKey, TValue>>[] _array;
        readonly AtomicReference<Thread> _edit;

        public HashCollisionNode(AtomicReference<Thread> edit, int hash, int count, params UnionType<TKey, TValue, INode<TKey, TValue>>[] array)
        {
            this._edit = edit;
            this._count = count;
            this._hash = hash;
            this._array = array;
        }

        public INode<TKey, TValue> Assoc(int shift, int hash, TKey key, TValue val, Box<object> addedLeaf)
        {
            if (this._hash == hash)
            {
                int idx = FindIndex(key);
                if (idx != -1)
                {
                    if (this._array[idx + 1] == val)
                    {
                        return this;
                    }
                    return new HashCollisionNode<TKey, TValue>(
                        null,
                        hash,
                        this._count,
                        CloneAndSet(this._array, idx + 1, UnionType<TKey, TValue, INode<TKey, TValue>>.Create(val)));
                }

                var newArray = new UnionType<TKey, TValue, INode<TKey, TValue>>[2 * (this._count + 1)];
                System.Array.Copy(this._array, 0, newArray, 0, 2 * this._count);
                newArray[2 * this._count] = key;
                newArray[2 * this._count + 1] = val;
                addedLeaf.Value = addedLeaf;
                return new HashCollisionNode<TKey, TValue>(this._edit, hash, this._count + 1, newArray);
            }

            return new BitmapIndexedNode<TKey, TValue>(null, Bitpos(this._hash, shift), new UnionType<TKey, TValue, INode<TKey, TValue>>[] { null, this })
                .Assoc(shift, hash, key, val, addedLeaf);
        }

        public INode<TKey, TValue> Assoc(AtomicReference<Thread> edit, int shift, int hash, TKey key, TValue val, Box<object> addedLeaf)
        {
            if (this._hash == hash)
            {
                int idx = FindIndex(key);
                if (idx != -1)
                {
                    if (this._array[idx + 1] == val)
                    {
                        return this;
                    }

                    return EditAndSet(edit, idx + 1, val);
                }

                if (this._array.Length > 2 * this._count)
                {
                    addedLeaf.Value = addedLeaf;
                    var editable = EditAndSet(edit, 2 * this._count, key, 2 * this._count + 1, val);
                    editable._count++;
                    return editable;
                }

                var newArray = new UnionType<TKey, TValue, INode<TKey, TValue>>[this._array.Length + 2];
                System.Array.Copy(this._array, 0, newArray, 0, this._array.Length);
                newArray[this._array.Length] = key;
                newArray[this._array.Length + 1] = val;
                addedLeaf.Value = addedLeaf;
                return EnsureEditable(edit, this._count + 1, newArray);
            }

            return new BitmapIndexedNode<TKey, TValue>(edit, Bitpos(this._hash, shift), new UnionType<TKey, TValue, INode<TKey, TValue>>[] { null, this, null, null })
                .Assoc(edit, shift, hash, key, val, addedLeaf);
        }

        public INode<TKey, TValue> Without(int shift, int hash, TKey key)
        {
            int idx = FindIndex(key);

            if (idx == -1)
            {
                return this;
            }
            if (this._count == 1)
            {
                return null;
            }

            return new HashCollisionNode<TKey, TValue>(null, hash, this._count - 1, RemovePair(this._array, idx / 2));
        }

        public INode<TKey, TValue> Without(AtomicReference<Thread> edit, int shift, int hash, TKey key, Box<object> removedLeaf)
        {
            int idx = FindIndex(key);

            if (idx == -1)
            {
                return this;
            }

            removedLeaf.Value = removedLeaf;
            if (this._count == 1)
            {
                return null;
            }

            var editable = EnsureEditable(edit);
            editable._array[idx] = editable._array[2 * this._count - 2];
            editable._array[idx + 1] = editable._array[2 * this._count - 1];
            editable._array[2 * this._count - 2] = editable._array[2 * this._count - 1] = null;
            editable._count--;
            return editable;
        }

        public IKeyValuePair<TKey, TValue> Get(int shift, int hash, TKey key)
        {
            int idx = FindIndex(key);

            if (idx < 0)
            {
                return null;
            }

            if (key == this._array[idx])
            {
                return KeyValuePair<TKey, TValue>.Create(this._array[idx], this._array[idx + 1]);
            }

            return null;
        }

        public TValue Get(int shift, int hash, TKey key, TValue notFound)
        {
            int idx = FindIndex(key);

            if (idx < 0)
            {
                return notFound;
            }

            if (key == this._array[idx])
            {
                return this._array[idx + 1];
            }

            return notFound;
        }

        public ISeq<IKeyValuePair<TKey, TValue>> GetNodeEnumerative() => NodeSeq<TKey, TValue>.Create(this._array);

        public System.Collections.Generic.IEnumerator<IKeyValuePair<TKey, TValue>> GetEnumerator(Func<TKey, UnionType<TValue, INode<TKey, TValue>>, IKeyValuePair<TKey, TValue>> d)
        {
            for (int i = 0; i < this._array.Length; i += 2)
            {
                var key = this._array[i];
                var nodeOrVal = this._array[i + 1];

                if (key != null)
                {
                    yield return d(key, UnionType<TValue, INode<TKey, TValue>>.Create(nodeOrVal));
                }
                else if (nodeOrVal != null)
                {
                    var ie = nodeOrVal.Item3.GetEnumerator(d);
                    while (ie.MoveNext())
                    {
                        yield return ie.Current;
                    }
                }
            }
        }

        public TAccumulate Reduce<TAccumulate>(Func<TAccumulate, UnionType<TKey, TValue, INode<TKey, TValue>>, UnionType<TKey, TValue, INode<TKey, TValue>>, TAccumulate> f, TAccumulate init) => NodeSeq<TKey, TValue>.Reduce(this._array, f, init);

        int FindIndex(TKey key)
        {
            for (int i = 0; i < 2 * this._count; i += 2)
            {
                if (key == this._array[i])
                {
                    return i;
                }
            }
            return -1;
        }

        HashCollisionNode<TKey, TValue> EnsureEditable(AtomicReference<Thread> edit)
        {
            if (this._edit == edit)
            {
                return this;
            }

            var newArray = new UnionType<TKey, TValue, INode<TKey, TValue>>[2 * (this._count + 1)];
            System.Array.Copy(this._array, 0, newArray, 0, 2 * this._count);
            return new HashCollisionNode<TKey, TValue>(edit, this._hash, this._count, newArray);
        }

        HashCollisionNode<TKey, TValue> EnsureEditable(AtomicReference<Thread> edit, int count, UnionType<TKey, TValue, INode<TKey, TValue>>[] array)
        {
            if (this._edit == edit)
            {
                this._array = array;
                this._count = count;
                return this;
            }

            return new HashCollisionNode<TKey, TValue>(edit, this._hash, count, array);
        }

        HashCollisionNode<TKey, TValue> EditAndSet(AtomicReference<Thread> edit, int i, UnionType<TKey, TValue, INode<TKey, TValue>> a)
        {
            var editable = EnsureEditable(edit);
            editable._array[i] = a;
            return editable;
        }

        HashCollisionNode<TKey, TValue> EditAndSet(AtomicReference<Thread> edit, int i, UnionType<TKey, TValue, INode<TKey, TValue>> a, int j, UnionType<TKey, TValue, INode<TKey, TValue>> b)
        {
            var editable = EnsureEditable(edit);
            editable._array[i] = a;
            editable._array[j] = b;
            return editable;
        }
    }
}