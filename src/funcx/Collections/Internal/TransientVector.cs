using System;
using System.Text;
using System.Threading;

namespace FunctionalLibrary.Collections.Internal
{
    class TransientVector :
        ITransientVector
    {
        static readonly object NOT_FOUND = new object();

        volatile int _count;
        volatile int _shift;
        volatile VectorNode _root;
        volatile object[] _tail;

        TransientVector(int count, int shift, VectorNode root, object[] tail)
        {
            this._count = count;
            this._shift = shift;
            this._root = root;
            this._tail = tail;
        }

        public TransientVector(Vector v) :
            this(v.Count, v.Shift, EditableRoot(v.Root), EditableTail(v.Tail))
        { }
        
        public object this[int index]
        {
            get => ToArray(index)[index & 0x01f];
            set => throw new NotImplementedException();
        }
        public object this[int index, object notFound]
        {
            get => index >= 0 && index < this._count ? this[index] : notFound;
            set => throw new NotImplementedException();
        }

        public int Count => EnsureEditable() ? this._count : -1;
        public ITransientVector Assoc(int i, object val)
        {
            EnsureEditable();
            if (i >= 0 && i < this._count)
            {
                if (i >= TailOff())
                {
                    this._tail[i & 0x01f] = val;
                    return this;
                }

                this._root = assoc(this._shift, this._root, i, val);
                return this;
            }
            if (i == this._count)
                return (ITransientVector)Conj(val);

            throw new ArgumentOutOfRangeException(nameof(i));

            VectorNode assoc(int level, VectorNode node, int idx, object value)
            {
                node = EnsureEditable(node);
                var ret = new VectorNode(node.Edit, (object[])node.Array.Clone());
                if (level == 0)
                    ret.Array[idx & 0x01f] = value;
                else
                {
                    int subIdx = (idx >> level) & 0x01f;
                    ret.Array[subIdx] = assoc(level - 5, (VectorNode)node.Array[subIdx], idx, value);
                }

                return ret;
            }
        }
        public ITransientVector Pop()
        {
            EnsureEditable();
            if (this._count == 0)
                throw new InvalidOperationException($"Cannot {nameof(Pop)} an empty {nameof(TransientVector)}");
            if (this._count == 1)
            {
                this._count = 0;
                return this;
            }
            int i = this._count - 1;

            if ((i & 0x01f) > 0)
            {
                --this._count;
                return this;
            }

            var newTail = ToEditableArray(this._count - 2);
            var newRoot = PopTail(this._shift, this._root) ?? new VectorNode(this._root.Edit);
            int newShift = this._shift;
            if (this._shift > 5 && newRoot.Array[1] == null)
            {
                newRoot = EnsureEditable((VectorNode)newRoot.Array[0]);
                newShift -= 5;
            }

            this._root = newRoot;
            this._shift = newShift;
            --this._count;
            this._tail = newTail;

            return this;
        }
        public bool ContainsKey(object key) => GetValue(key, NOT_FOUND) != NOT_FOUND;
        public ITransientAssociative Assoc(object key, object val) =>
            int.TryParse(key.ToString(), out int i)
                ? Assoc(i, val)
                : throw new ArgumentException($"{nameof(key)} must be an integer.");
        public System.Collections.Generic.KeyValuePair<object, object>? Get(object key)
        {
            var v = GetValue(key, NOT_FOUND);
            if (v != NOT_FOUND)
                return new System.Collections.Generic.KeyValuePair<object, object>(key, v);
            return null;
        }
        public ITransientCollection Conj(object val)
        {
            EnsureEditable();
            int i = this._count;
            if (i - TailOff() < 32)
            {
                this._tail[i & 0x01f] = val;
                ++this._count;
                return this;
            }
            VectorNode newRoot;
            var tailNode = new VectorNode(this._root.Edit, this._tail);
            this._tail = new object[32];
            this._tail[0] = val;
            int newShift = this._shift;

            if ((this._count >> 5) > (1 << this._shift))
            {
                newRoot = new VectorNode(this._root.Edit);
                newRoot.Array[0] = this._root;
                newRoot.Array[1] = Vector.NewPath(this._root.Edit, this._shift, tailNode);
                newShift += 5;
            }
            else
                newRoot = PushTail(this._shift, this._root, tailNode);

            this._root = newRoot;
            this._shift = newShift;
            ++this._count;
            return this;
        }
        public IVector ToPersistent()
        {
            EnsureEditable();
            this._root.Edit.Set(null);
            var trimmedTail = new object[this._count - TailOff()];
            System.Array.Copy(this._tail, trimmedTail, trimmedTail.Length);
            return new Vector(this._count, this._shift, this._root, trimmedTail);
        }

        ICollection ITransientCollection.ToPersistent() => ToPersistent();
        public object GetValue(object key) => GetValue(key, null);
        public object GetValue(object key, object notFound)
        {
            EnsureEditable();
            return int.TryParse(key.ToString(), out int i) && i >= 0 && i < Count
                ? this[i]
                : notFound;
        }


        static VectorNode EditableRoot(VectorNode node) =>
            new VectorNode(new AtomicReference<Thread>(Thread.CurrentThread), (object[])node.Array.Clone());

        static object[] EditableTail(object[] tail)
        {
            var ret = new object[32];
            System.Array.Copy(tail, ret, tail.Length);
            return ret;
        }

        bool EnsureEditable()
        {
            var owner = this._root.Edit.Get();
            if (owner == null)
                throw new InvalidOperationException("Transient used after persistent! call");
            return true;
        }

        VectorNode EnsureEditable(VectorNode node) =>
            node.Edit == this._root.Edit
                ? node
                : new VectorNode(this._root.Edit, (object[])node.Array.Clone());

        VectorNode PushTail(int level, VectorNode parent, VectorNode tailNode)
        {
            //if parent is leaf, insert node,
            // else does it map to an existing child? -> nodeToInsert = pushNode one more level
            // else alloc new path
            //return  nodeToInsert placed in copy of parent
            int subIdx = ((this._count - 1) >> level) & 0x01f;
            var ret = new VectorNode(parent.Edit, (object[])parent.Array.Clone());
            VectorNode nodeToInsert;

            if (level == 5)
                nodeToInsert = tailNode;
            else
            {
                var child = (VectorNode)parent.Array[subIdx];
                nodeToInsert =
                    child != null
                        ? PushTail(level - 5, child, tailNode)
                        : Vector.NewPath(this._root.Edit, level - 5, tailNode);
            }

            ret.Array[subIdx] = nodeToInsert;
            return ret;
        }

        int TailOff() => this._count < 32 ? 0 : ((this._count - 1) >> 5) << 5;

        object[] ToArray(int i)
        {
            if (i >= 0 && i < this._count)
            {
                if (i >= TailOff()) return this._tail;
                var node = this._root;
                for (int level = this._shift; level > 0; level -= 5)
                    node = (VectorNode)node.Array[(i >> level) & 0x01f];
                return node.Array;
            }
            throw new ArgumentOutOfRangeException(nameof(i));
        }

        object[] ToEditableArray(int i)
        {
            if (i >= 0 && i < this._count)
            {
                if (i >= TailOff()) return this._tail;
                var node = this._root;
                for (int level = this._shift; level > 0; level -= 5)
                    node = EnsureEditable((VectorNode)node.Array[(i >> level) & 0x01f]);
                return node.Array;
            }
            throw new ArgumentOutOfRangeException(nameof(i));
        }

        VectorNode PopTail(int level, VectorNode node)
        {
            node = EnsureEditable(node);
            int subIdx = ((this._count - 2) >> level) & 0x01f;
            if (level > 5)
            {
                var newChild = PopTail(level - 5, (VectorNode)node.Array[subIdx]);
                if (newChild == null && subIdx == 0)
                    return null;
                else
                {
                    var ret = node;
                    ret.Array[subIdx] = newChild;
                    return ret;
                }
            }
            else if (subIdx == 0) return null;
            else
            {
                var ret = node;
                ret.Array[subIdx] = null;
                return ret;
            }
        }
    }
}
