using System;
using System.Text;
using System.Threading;
using funclib.Components.Core;
using static FunctionalLibrary.Util;

namespace funclib.Collections.Internal
{
    sealed class ArrayNode :
        INode
    {
        int _count;
        readonly INode[] _array;
        [NonSerialized]
        readonly AtomicReference<Thread> _edit;

        public ArrayNode(AtomicReference<Thread> edit, int count, INode[] array)
        {
            this._array = array;
            this._edit = edit;
            this._count = count;
        }

        public INode Assoc(int shift, int hash, object key, object val, Box addedLeaf)
        {
            int idx = Mask(hash, shift);

            var node = this._array[idx];
            if (node == null)
                return new ArrayNode(null, this._count + 1, CloneAndSet(this._array, idx, BitmapIndexedNode.EMPTY.Assoc(shift + 5, hash, key, val, addedLeaf)));

            var n = node.Assoc(shift + 5, hash, key, val, addedLeaf);
            if (n == node) return this;

            return new ArrayNode(null, this._count, CloneAndSet(this._array, idx, n));
        }
        public INode Assoc(AtomicReference<Thread> edit, int shift, int hash, object key, object val, Box addedLeaf)
        {
            int idx = Mask(hash, shift);
            var node = this._array[idx];
            if (node == null)
            {
                var editable = EditAndSet(edit, idx, BitmapIndexedNode.EMPTY.Assoc(edit, shift + 5, hash, key, val, addedLeaf));
                editable._count++;
                return editable;
            }

            var n = node.Assoc(edit, shift + 5, hash, key, val, addedLeaf);
            if (n == node) return this;

            return EditAndSet(edit, idx, n);
        }
        public IKeyValuePair Get(int shift, int hash, object key)
        {
            int idx = Mask(hash, shift);
            var node = this._array[idx];
            if (node == null) return null;

            return node.Get(shift + 5, hash, key);
        }
        public object Get(int shift, int hash, object key, object notFound)
        {
            int idx = Mask(hash, shift);
            var node = this._array[idx];
            if (node == null) return notFound;

            return node.Get(shift + 5, hash, key, notFound);
        }
        public INode Without(int shift, int hash, object key)
        {
            int idx = Mask(hash, shift);
            var node = this._array[idx];
            if (node == null) return this;

            var n = node.Without(shift + 5, hash, key);
            if (n == node) return this;

            if (n == null)
            {
                if (this._count <= 8) return Pack(null, idx);

                return new ArrayNode(null, this._count - 1, CloneAndSet(this._array, idx, n));
            }

            return new ArrayNode(null, this._count, CloneAndSet(this._array, idx, n));
        }
        public INode Without(AtomicReference<Thread> edit, int shift, int hash, object key, Box removedLeaf)
        {
            int idx = Mask(hash, shift);
            var node = this._array[idx];
            if (node == null) return this;

            var n = node.Without(edit, shift + 5, hash, key, removedLeaf);
            if (n == node) return this;

            if (n == null)
            {
                if (this._count <= 8) return Pack(edit, idx);

                var editable = EditAndSet(edit, idx, n);
                editable._count--;
                return editable;
            }

            return EditAndSet(edit, idx, n);
        }

        public ISeq GetNodeEnumerative() => ArrayNodeSeq.Create(this._array);

        public System.Collections.IEnumerator GetEnumerator(Func<object, object, object> d)
        {
            foreach (var node in this._array)
            {
                if (node != null)
                {
                    var e = node.GetEnumerator(d);
                    while (e.MoveNext())
                        yield return e.Current;
                }
            }
        }

        ArrayNode EnsureEditable(AtomicReference<Thread> edit)
        {
            if (this._edit == edit)
                return this;

            return new ArrayNode(edit, this._count, this._array.Clone() as INode[]);
        }

        ArrayNode EditAndSet(AtomicReference<Thread> edit, int i, INode n)
        {
            var editable = EnsureEditable(edit);
            editable._array[i] = n;
            return editable;
        }

        INode Pack(AtomicReference<Thread> edit, int idx)
        {
            var newArray = new object[2 * (this._count - 1)];
            int j = 1;
            int bitmap = 0;
            for (int i = 0; i < idx; i++)
            {
                if (this._array[i] != null)
                {
                    newArray[j] = this._array[i];
                    bitmap |= 1 << i;
                    j += 2;
                }
            }
            for (int i = idx + 1; i < this._array.Length; i++)
            {
                if (this._array[i] != null)
                {
                    newArray[j] = this._array[i];
                    bitmap |= 1 << i;
                    j += 2;
                }
            }
            return new BitmapIndexedNode(edit, bitmap, newArray);
        }

        public object Reduce(IFunction f, object init)
        {
            foreach (var node in this._array)
            {
                if (node != null)
                {
                    init = node.Reduce(f, init);
                    if (init is Reduced) return init;
                }
            }
            return init;
        }
    }
}
