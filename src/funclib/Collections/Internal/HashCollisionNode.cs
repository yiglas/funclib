using funclib.Collections.Generic;
using System;
using System.Threading;
using static funclib.Util;

namespace funclib.Collections.Internal
{
    [Serializable]
    sealed class HashCollisionNode :
        INode
    {
        readonly int _hash;
        int _count;
        object[] _array;
        [NonSerialized]
        readonly AtomicReference<Thread> _edit;

        public HashCollisionNode(AtomicReference<Thread> edit, int hash, int count, params object[] array)
        {
            this._edit = edit;
            this._count = count;
            this._hash = hash;
            this._array = array;
        }

        public INode Assoc(int shift, int hash, object key, object val, Box addedLeaf)
        {
            if (this._hash == hash)
            {
                int idx = FindIndex(key);
                if (idx != -1)
                {
                    if (this._array[idx + 1] == val) return this;
                    return new HashCollisionNode(null, hash, this._count, CloneAndSet(this._array, idx + 1, val));
                }

                var newArray = new object[2 * (this._count + 1)];
                System.Array.Copy(this._array, 0, newArray, 0, 2 * this._count);
                newArray[2 * this._count] = key;
                newArray[2 * this._count + 1] = val;
                addedLeaf.Value = addedLeaf;
                return new HashCollisionNode(this._edit, hash, this._count + 1, newArray);
            }

            return new BitmapIndexedNode(null, Bitpos(this._hash, shift), new object[] { null, this })
                .Assoc(shift, hash, key, val, addedLeaf);
        }

        public INode Assoc(AtomicReference<Thread> edit, int shift, int hash, object key, object val, Box addedLeaf)
        {
            if (this._hash == hash)
            {
                int idx = FindIndex(key);
                if (idx != -1)
                {
                    if (this._array[idx + 1] == val) return this;

                    return EditAndSet(edit, idx + 1, val);
                }

                if (this._array.Length > 2 * this._count)
                {
                    addedLeaf.Value = addedLeaf;
                    var editable = EditAndSet(edit, 2 * this._count, key, 2 * this._count + 1, val);
                    editable._count++;
                    return editable;
                }

                var newArray = new object[this._array.Length + 2];
                System.Array.Copy(this._array, 0, newArray, 0, this._array.Length);
                newArray[this._array.Length] = key;
                newArray[this._array.Length + 1] = val;
                addedLeaf.Value = addedLeaf;
                return EnsureEditable(edit, this._count + 1, newArray);
            }

            return new BitmapIndexedNode(edit, Bitpos(this._hash, shift), new object[] { null, this, null, null })
                .Assoc(edit, shift, hash, key, val, addedLeaf);
        }

        public IKeyValuePair Get(int shift, int hash, object key)
        {
            int idx = FindIndex(key);

            if (idx < 0) return null;
            if ((bool)funclib.Core.IsEqualTo(key, this._array[idx])) return new KeyValuePair(this._array[idx], this._array[idx + 1]);

            return null;
        }

        public object Get(int shift, int hash, object key, object notFound)
        {
            int idx = FindIndex(key);

            if (idx < 0) return notFound;
            if ((bool)funclib.Core.IsEqualTo(key, this._array[idx])) return this._array[idx + 1];

            return notFound;
        }

        public INode Without(int shift, int hash, object key)
        {
            int idx = FindIndex(key);

            if (idx == -1) return this;
            if (this._count == 1) return null;

            return new HashCollisionNode(null, hash, this._count - 1, RemovePair(this._array, idx / 2));
        }

        public INode Without(AtomicReference<Thread> edit, int shift, int hash, object key, Box removedLeaf)
        {
            int idx = FindIndex(key);

            if (idx == -1) return this;
            removedLeaf.Value = removedLeaf;
            if (this._count == 1) return null;

            var editable = EnsureEditable(edit);
            editable._array[idx] = editable._array[2 * this._count - 2];
            editable._array[idx + 1] = editable._array[2 * this._count - 1];
            editable._array[2 * this._count - 2] = editable._array[2 * this._count - 1] = null;
            editable._count--;
            return editable;
        }

        public ISeq GetNodeEnumerative() => NodeSeq.Create(this._array);

        public System.Collections.IEnumerator GetEnumerator(Func<object, object, object> d)
        {
            for (int i = 0; i < this._array.Length; i += 2)
            {
                var key = this._array[i];
                var nodeOrVal = this._array[i + 1];

                if (key != null) yield return d(key, nodeOrVal);
                else if (nodeOrVal != null)
                {
                    var ie = ((INode)nodeOrVal).GetEnumerator(d);
                    while (ie.MoveNext())
                        yield return ie.Current;
                }
            }
        }

        int FindIndex(object key)
        {
            for (int i = 0; i < 2 * this._count; i += 2)
            {
                if ((bool)funclib.Core.IsEqualTo(key, this._array[i]))
                    return i;
            }
            return -1;
        }

        HashCollisionNode EnsureEditable(AtomicReference<Thread> edit)
        {
            if (this._edit == edit) return this;
            var newArray = new object[2 * (this._count + 1)];
            System.Array.Copy(this._array, 0, newArray, 0, 2 * this._count);
            return new HashCollisionNode(edit, this._hash, this._count, newArray);
        }

        HashCollisionNode EnsureEditable(AtomicReference<Thread> edit, int count, object[] array)
        {
            if (this._edit == edit)
            {
                this._array = array;
                this._count = count;
                return this;
            }

            return new HashCollisionNode(edit, this._hash, count, array);
        }

        HashCollisionNode EditAndSet(AtomicReference<Thread> edit, int i, object a)
        {
            var editable = EnsureEditable(edit);
            editable._array[i] = a;
            return editable;
        }

        HashCollisionNode EditAndSet(AtomicReference<Thread> edit, int i, object a, int j, object b)
        {
            var editable = EnsureEditable(edit);
            editable._array[i] = a;
            editable._array[j] = b;
            return editable;
        }

        public object Reduce(object f, object init) => NodeSeq.Reduce(this._array, f, init);
    }
}
