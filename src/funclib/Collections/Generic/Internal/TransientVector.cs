using System;
using System.Threading;

namespace funclib.Collections.Generic.Internal
{
    class TransientVector<T> :
        ITransientVector<T>
    {
        volatile int _count;
        volatile int _shift;
        volatile VectorNode<T> _root;
        volatile UnionType<T, VectorNode<T>>[] _tail;

        TransientVector(int count, int shift, VectorNode<T> root, UnionType<T, VectorNode<T>>[] tail)
        {
            this._count = count;
            this._shift = shift;
            this._root = root;
            this._tail = tail;
        }

        public TransientVector(Vector<T> v) :
            this(v.Count, v.Shift, EditableRoot(v.Root), EditableTail(v.Tail))
        { }

        public T this[int index]
        {
            get => ToArray(index)[index & 0x01f];
            set => throw new NotImplementedException();
        }

        public T this[int index, T notFound]
        {
            get
            {
                if (index >= 0 && index < this._count)
                {
                    return this[index];
                 }

                 return notFound;
            }
            set => throw new NotImplementedException();
        }

        public int Count => EnsureEditable() ? this._count : -1;

        public ITransientVector<T> Assoc(int i, T val)
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
            {
                return Conj(val);
            }

            throw new ArgumentOutOfRangeException(nameof(i));

            VectorNode<T> assoc(int level, VectorNode<T> node, int idx, T value)
            {
                node = EnsureEditable(node);
                var ret = new VectorNode<T>(node.Edit, (UnionType<T, VectorNode<T>>[])node.Array.Clone());
                if (level == 0)
                {
                    ret.Array[idx & 0x01f] = value;
                }
                else
                {
                    int subIdx = (idx >> level) & 0x01f;
                    ret.Array[subIdx] = assoc(level - 5, (VectorNode<T>)node.Array[subIdx], idx, value);
                }

                return ret;
            }
        }

        public ITransientVector<T> Conj(T val)
        {
            EnsureEditable();
            int i = this._count;
            if (i - TailOff() < 32)
            {
                this._tail[i & 0x01f] = val;
                ++this._count;
                return this;
            }

            VectorNode<T> newRoot;
            var tailNode = new VectorNode<T>(this._root.Edit, this._tail);
            this._tail = new UnionType<T, VectorNode<T>>[32];
            this._tail[0] = val;
            int newShift = this._shift;

            if ((this._count >> 5) > (1 << this._shift))
            {
                newRoot = new VectorNode<T>(this._root.Edit);
                newRoot.Array[0] = this._root;
                newRoot.Array[1] = Vector<T>.NewPath(this._root.Edit, this._shift, tailNode);
                newShift += 5;
            }
            else
            {
                newRoot = PushTail(this._shift, this._root, tailNode);
            }

            this._root = newRoot;
            this._shift = newShift;
            ++this._count;
            return this;
        }

        public bool ContainsKey(int key) => (key >= 0 && key < Count);

        public IKeyValuePair<int, T> Get(int key)
        {
            if (ContainsKey(key))
            {
                var v = GetValue(key);
                return KeyValuePair<int, T>.Create(key, v);
            }

            return null;
        }

        public T GetValue(int key)
        {
            EnsureEditable();
            if (ContainsKey(key))
            {
                return this[key];
            }

            return default;
        }

        public T GetValue(int key, T notFound)
        {
            EnsureEditable();
            if (ContainsKey(key))
            {
                return this[key];
            }

            return notFound;
        }

        public ITransientVector<T> Pop()
        {
            EnsureEditable();
            if (this._count == 0)
            {
                throw new InvalidOperationException($"Cannot {nameof(Pop)} an empty {nameof(TransientVector<T>)}");
            }
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
            var newRoot = PopTail(this._shift, this._root) ?? new VectorNode<T>(this._root.Edit);
            int newShift = this._shift;
            if (this._shift > 5 && !newRoot.Array[1].HasValue)
            {
                newRoot = EnsureEditable((VectorNode<T>)newRoot.Array[0]);
                newShift -= 5;
            }

            this._root = newRoot;
            this._shift = newShift;
            --this._count;
            this._tail = newTail;

            return this;
        }

        public IVector<T> ToPersistent()
        {
            EnsureEditable();
            this._root.Edit.Set(null);
            var trimmedTail = new UnionType<T, VectorNode<T>>[this._count - TailOff()];
            System.Array.Copy(this._tail, trimmedTail, trimmedTail.Length);
            return new Vector<T>(this._count, this._shift, this._root, trimmedTail);
        }

        ITransientAssociative<int, T> ITransientAssociative<int, T>.Assoc(int key, T val) => Assoc(key, val);

        ICollection<IKeyValuePair<int, T>> ITransientCollection<IKeyValuePair<int, T>>.ToPersistent() => ToPersistent();

        public ITransientCollection<IKeyValuePair<int, T>> Conj(IKeyValuePair<int, T> val) => Conj(val.Value);

        bool EnsureEditable()
        {
            var owner = this._root.Edit.Get();

            if (owner is null)
            {
                throw new InvalidOperationException("Transient used after persistent! call");
            }

            return true;
        }

        VectorNode<T> EnsureEditable(VectorNode<T> node)
        {
            if (node.Edit == this._root.Edit)
            {
                return node;
            }

            return new VectorNode<T>(this._root.Edit, (UnionType<T, VectorNode<T>>[])node.Array.Clone());
        }
        VectorNode<T> PushTail(int level, VectorNode<T> parent, VectorNode<T> tailNode)
        {
            //if parent is leaf, insert node,
            // else does it map to an existing child? -> nodeToInsert = pushNode one more level
            // else alloc new path
            //return  nodeToInsert placed in copy of parent
            int subIdx = ((this._count - 1) >> level) & 0x01f;
            var ret = new VectorNode<T>(parent.Edit, (UnionType<T, VectorNode<T>>[])parent.Array.Clone());
            VectorNode<T> nodeToInsert;

            if (level == 5)
                nodeToInsert = tailNode;
            else
            {
                var child = (VectorNode<T>)parent.Array[subIdx];
                nodeToInsert =
                    child != null
                        ? PushTail(level - 5, child, tailNode)
                        : Vector<T>.NewPath(this._root.Edit, level - 5, tailNode);
            }

            ret.Array[subIdx] = nodeToInsert;
            return ret;
        }

        int TailOff() => this._count < 32 ? 0 : ((this._count - 1) >> 5) << 5;

        UnionType<T, VectorNode<T>>[] ToArray(int i)
        {
            if (i >= 0 && i < this._count)
            {
                if (i >= TailOff())
                {
                    return this._tail;
                }

                var node = this._root;

                for (int level = this._shift; level > 0; level -= 5)
                {
                    node = (VectorNode<T>)node.Array[(i >> level) & 0x01f];
                }
                return node.Array;
            }

            throw new ArgumentOutOfRangeException(nameof(i));
        }


        UnionType<T, VectorNode<T>>[] ToEditableArray(int i)
        {
            if (i >= 0 && i < this._count)
            {
                if (i >= TailOff())
                {
                    return this._tail;
                }

                var node = this._root;

                for (int level = this._shift; level > 0; level -= 5)
                {
                    node = EnsureEditable((VectorNode<T>)node.Array[(i >> level) & 0x01f]);
                }

                return node.Array;
            }

            throw new ArgumentOutOfRangeException(nameof(i));
        }

        VectorNode<T> PopTail(int level, VectorNode<T> node)
        {
            node = EnsureEditable(node);
            int subIdx = ((this._count - 2) >> level) & 0x01f;
            if (level > 5)
            {
                var newChild = PopTail(level - 5, (VectorNode<T>)node.Array[subIdx]);
                if (newChild is null && subIdx == 0)
                {
                    return null;
                }
                else
                {
                    var ret = node;
                    ret.Array[subIdx] = newChild;
                    return ret;
                }
            }
            else if (subIdx == 0)
            {
                return null;
            }
            else
            {
                var ret = node;
                ret.Array[subIdx] = null;
                return ret;
            }
        }
        static VectorNode<T> EditableRoot(VectorNode<T> node)
        {
            return new VectorNode<T>(new AtomicReference<Thread>(Thread.CurrentThread), (UnionType<T, VectorNode<T>>[])node.Array.Clone());
        }

        static UnionType<T, VectorNode<T>>[] EditableTail(UnionType<T, VectorNode<T>>[] tail)
        {
            var ret = new UnionType<T, VectorNode<T>>[32];
            System.Array.Copy(tail, ret, tail.Length);
            return ret;
        }

        ITransientCollection<T> ITransientCollection<T>.Conj(T val) => Conj(val);

        ICollection<T> ITransientCollection<T>.ToPersistent() => ToPersistent();
    }
}
