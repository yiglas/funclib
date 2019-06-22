using System;
using System.Threading;
using static funclib.Util;

namespace funclib.Collections.Generic.Internal
{
    sealed class ArrayNode<TKey, TValue> :
        INode<TKey, TValue>
    {
        int _count;
        readonly INode<TKey, TValue>[] _array;
        readonly AtomicReference<Thread> _edit;

        public ArrayNode(AtomicReference<Thread> edit, int count, INode<TKey, TValue>[] array)
        {
            this._array = array;
            this._edit = edit;
            this._count = count;
        }

        public INode<TKey, TValue> Assoc(int shift, int hash, TKey key, TValue val, Box<object> addedLeaf)
        {
            int idx = Mask(hash, shift);

            var node = this._array[idx];
            if (node is null)
            {
                return new ArrayNode<TKey, TValue>(null, this._count + 1, CloneAndSet(this._array, idx, BitmapIndexedNode<TKey, TValue>.EMPTY.Assoc(shift + 5, hash, key, val, addedLeaf)));
            }

            var n = node.Assoc(shift + 5, hash, key, val, addedLeaf);

            if (n == node)
            {
                return this;
            }

            return new ArrayNode<TKey, TValue>(null, this._count, CloneAndSet(this._array, idx, n));
        }

        public INode<TKey, TValue> Assoc(AtomicReference<Thread> edit, int shift, int hash, TKey key, TValue val, Box<object> addedLeaf)
        {
            int idx = Mask(hash, shift);
            var node = this._array[idx];
            if (node is null)
            {
                var editable = EditAndSet(edit, idx, BitmapIndexedNode<TKey, TValue>.EMPTY.Assoc(edit, shift + 5, hash, key, val, addedLeaf));
                editable._count++;
                return editable;
            }

            var n = node.Assoc(edit, shift + 5, hash, key, val, addedLeaf);
            if (n == node)
            {
                return this;
            }

            return EditAndSet(edit, idx, n);
        }

        public IKeyValuePair<TKey, TValue> Get(int shift, int hash, TKey key)
        {
            int idx = Mask(hash, shift);
            var node = this._array[idx];
            if (node is null)
            {
                return null;
            }

            return node.Get(shift + 5, hash, key);
        }

        public TValue Get(int shift, int hash, TKey key, TValue notFound)
        {
            int idx = Mask(hash, shift);
            var node = this._array[idx];
            if (node is null)
            {
                return notFound;
            }

            return node.Get(shift + 5, hash, key, notFound);
        }

        public System.Collections.Generic.IEnumerator<IKeyValuePair<TKey, TValue>> GetEnumerator(Func<TKey, UnionType<TValue, INode<TKey, TValue>>, IKeyValuePair<TKey, TValue>> d)
        {
            foreach (var node in this._array)
            {
                if (node != null)
                {
                    var e = node.GetEnumerator(d);
                    while (e.MoveNext())
                    {
                        yield return e.Current;
                    }
                }
            }
        }

        public ISeq<IKeyValuePair<TKey, TValue>> GetNodeEnumerative() => ArrayNodeSeq<TKey, TValue>.Create(this._array);

        public TAccumulate Reduce<TAccumulate>(Func<TAccumulate, UnionType<TKey, TValue, INode<TKey, TValue>>, UnionType<TKey, TValue, INode<TKey, TValue>>, TAccumulate> f, TAccumulate init)
        {
            foreach (var node in this._array)
            {
                if (node != null)
                {
                    init = node.Reduce(f, init);
                }
            }
            return init;
        }

        public INode<TKey, TValue> Without(int shift, int hash, TKey key)
        {
            int idx = Mask(hash, shift);
            var node = this._array[idx];
            if (node is null)
            {
                return this;
            }

            var n = node.Without(shift + 5, hash, key);
            if (n == node)
            {
                return this;
            }

            if (n is null)
            {
                if (this._count <= 8)
                {
                    return Pack(null, idx);
                }

                return new ArrayNode<TKey, TValue>(null, this._count - 1, CloneAndSet(this._array, idx, n));
            }

            return new ArrayNode<TKey, TValue>(null, this._count, CloneAndSet(this._array, idx, n));
        }

        public INode<TKey, TValue> Without(AtomicReference<Thread> edit, int shift, int hash, TKey key, Box<object> removedLeaf)
        {
            int idx = Mask(hash, shift);
            var node = this._array[idx];
            if (node is null)
            {
                return this;
            }

            var n = node.Without(edit, shift + 5, hash, key, removedLeaf);
            if (n == node)
            {
                return this;
            }

            if (n is null)
            {
                if (this._count <= 8) return Pack(edit, idx);

                var editable = EditAndSet(edit, idx, n);
                editable._count--;
                return editable;
            }

            return EditAndSet(edit, idx, n);
        }

        ArrayNode<TKey, TValue> EnsureEditable(AtomicReference<Thread> edit)
        {
            if (this._edit == edit)
            {
                return this;
            }

            return new ArrayNode<TKey, TValue>(edit, this._count, this._array.Clone() as INode<TKey, TValue>[]);
        }

        ArrayNode<TKey, TValue> EditAndSet(AtomicReference<Thread> edit, int i, INode<TKey, TValue> n)
        {
            var editable = EnsureEditable(edit);
            editable._array[i] = n;
            return editable;
        }

        INode<TKey, TValue> Pack(AtomicReference<Thread> edit, int idx)
        {
            var newArray = new UnionType<TKey, TValue, INode<TKey, TValue>>[2 * (this._count - 1)];
            int j = 1;
            int bitmap = 0;
            for (int i = 0; i < idx; i++)
            {
                if (this._array[i] != null)
                {
                    newArray[j] = UnionType<TKey, TValue, INode<TKey, TValue>>.Create(this._array[i]);
                    bitmap |= 1 << i;
                    j += 2;
                }
            }
            for (int i = idx + 1; i < this._array.Length; i++)
            {
                if (this._array[i] != null)
                {
                    newArray[j] = UnionType<TKey, TValue, INode<TKey, TValue>>.Create(this._array[i]);
                    bitmap |= 1 << i;
                    j += 2;
                }
            }
            return new BitmapIndexedNode<TKey, TValue>(edit, bitmap, newArray);
        }
    }
}