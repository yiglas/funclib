using funclib.Collections.Generic;
using funclib.Collections.Internal.Generic;
using funclib.Components.Core;
using System;
using System.Linq;
using System.Threading;

namespace funclib.Collections
{
    public class Vector<T> :
        AVector<T>,
        IReduce<T>,
        IReduceKV<int, T>
    {
        static readonly AtomicReference<Thread> NoEdit = new AtomicReference<Thread>();
        internal static readonly VectorNode<T> EmptyNode = new VectorNode<T>(NoEdit, new UnionType<T, VectorNode<T>>[32]);
        public static readonly IVector<T> EMPTY = new Vector<T>(0, 5, EmptyNode, new UnionType<T, VectorNode<T>>[0]);

        internal int Shift { get; }
        internal VectorNode<T> Root { get; }
        internal UnionType<T, VectorNode<T>>[] Tail { get; }

        public override int Count { get; }
        public override T this[int index]
        {
            get => ToArray(index)[index & 0x01f];
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Vector)}.");
        }

        internal Vector(int count, int shift, VectorNode<T> root, UnionType<T, VectorNode<T>>[] tail)
        {
            Count = count;
            Shift = shift;
            Root = root;
            Tail = tail;
        }

        #region Creates
        public static Vector<T> Create(ISeq<T> init)
        {
            var arr = new UnionType<T, VectorNode<T>>[32];
            int i = 0;
            for (; init != null && i < 32; init = init.Next())
            {
                arr[i++] = init.First();
            }

            if (init != null)
            {
                var start = new Vector<T>(32, 5, EmptyNode, arr);
                var ret = start.ToTransient();
                for (; init != null; init = init.Next())
                {
                    ret = ret.Conj(init.First());
                }

                return ret.ToPersistent() as Vector<T>;
            }
            else if (i == 32)
            {
                return new Vector<T>(32, 5, EmptyNode, arr);
            }
            else
            {
                var arr2 = new UnionType<T, VectorNode<T>>[i];
                System.Array.Copy(arr, 0, arr2, 0, i);

                return new Vector<T>(i, 5, EmptyNode, arr2);
            }
        }

        public static Vector<T> Create(params T[] init)
        {
            if (init.Length <= 32)
            {
                return new Vector<T>(init.Length, 5, EmptyNode, init.Select(x => UnionType<T, VectorNode<T>>.Create(x)).ToArray());
            }

            var ret = EMPTY.ToTransient();
            foreach (var item in init)
            {
                ret = ret.Conj(item);
            }

            return ret.ToPersistent() as Vector<T>;
        }

        public static Vector<T> Create(System.Collections.Generic.IEnumerable<T> init)
        {
            if (init is IList<T> l)
            {
                int size = l.Count;
                if (size <= 32)
                {
                    var arr = l.Select(x => (UnionType<T, VectorNode<T>>)x).ToArray();

                    return new Vector<T>(size, 5, EmptyNode, arr);
                }
            }

            var ret = EMPTY.ToTransient();
            foreach (var item in init)
            {
                ret = ret.Conj(item);
            }

            return ret.ToPersistent() as Vector<T>;
        }
        #endregion

        #region Overrides
        public override IVector<T> Assoc(int i, T val)
        {
            if (i >= 0 && i < Count)
            {
                if (i >= TailOff())
                {
                    var newTail = new UnionType<T, VectorNode<T>>[this.Tail.Length];
                    System.Array.Copy(this.Tail, newTail, this.Tail.Length);
                    newTail[i & 0x01f] = val;

                    return new Vector<T>(Count, this.Shift, this.Root, newTail);
                }

                return new Vector<T>(Count, this.Shift, assoc(this.Shift, this.Root, i, val), this.Tail);
            }

            if (i == Count) return Cons(val);

            throw new ArgumentOutOfRangeException(nameof(i));

            VectorNode<T> assoc(int level, VectorNode<T> node, int idx, T value)
            {
                var ret = new VectorNode<T>(node.Edit, (UnionType<T, VectorNode<T>>[])node.Array.Clone());
                if (level == 0)
                    ret.Array[idx & 0x01f] = value;
                else
                {
                    int subIdx = (idx >> level) & 0x01f;
                    ret.Array[subIdx] = assoc(level - 5, node.Array[subIdx], idx, value);
                }

                return ret;
            }
        }
        public override IVector<T> Cons(T o)
        {
            if (Count - TailOff() < 32)
            {
                var newTail = new UnionType<T, VectorNode<T>>[Tail.Length + 1];
                System.Array.Copy(Tail, newTail, Tail.Length);
                newTail[Tail.Length] = o;
                return new Vector<T>(Count + 1, Shift, Root, newTail);
            }

            VectorNode<T> newRoot;
            var tailNode = new VectorNode<T>(Root.Edit, Tail);
            int newShift = Shift;

            if ((Count >> 5) > (1 << Shift))
            {
                newRoot = new VectorNode<T>(Root.Edit);
                newRoot.Array[0] = Root;
                newRoot.Array[1] = NewPath(Root.Edit, Shift, tailNode);
                newShift += 5;
            }
            else newRoot = PushTail(Shift, Root, tailNode);

            return new Vector<T>(Count + 1, newShift, newRoot, new UnionType<T, VectorNode<T>>[] { o });
        }
        public override IVector<T> Empty() => EMPTY;
        public override IStack<T> Pop()
        {
            if (Count == 0) throw new InvalidOperationException($"Cannot pop an empty {nameof(Vector)}.");
            if (Count == 1) return EMPTY;

            UnionType<T, VectorNode<T>>[] newTail;

            if (Count - TailOff() > 1)
            {
                newTail = new UnionType<T, VectorNode<T>>[this.Tail.Length - 1];
                System.Array.Copy(this.Tail, newTail, newTail.Length);
                return new Vector<T>(Count - 1, this.Shift, this.Root, newTail);
            }

            newTail = ToArray(Count - 2);
            var newRoot = PopTail(this.Shift, this.Root);
            int newShift = this.Shift;

            if (newRoot is null) newRoot = EmptyNode;
            if (this.Shift > 5 && newRoot.Array[1].HasValue == false)
            {
                newRoot = (VectorNode<T>)newRoot.Array[0];
                newShift -= 5;
            }

            return new Vector<T>(Count - 1, newShift, newRoot, newTail);
        }
        public override ISeq<T> Seq() => throw new NotImplementedException("TODO"); // Count == 0 ? null : new ChunkedSeq<T>(this, 0, 0);
        public override ITransientCollection<T> ToTransient() => throw new NotImplementedException("TODO"); // new TransientVector<T>(this);
        public override System.Collections.Generic.IEnumerator<T> GetEnumerator() => RangedEnumerator(0, Count);
        public override System.Collections.Generic.IEnumerator<T> RangedEnumerator(int start, int end)
        {
            int i = start;
            int b = i - (i % 32);
            var arr = start < Count ? ToArray(i) : null;

            while (i < end)
            {
                if (i - b == 32)
                {
                    arr = ToArray(i);
                    b += 32;
                }
                yield return arr[i++ & 0x01f];
            }
        }
        #endregion

        internal UnionType<T, VectorNode<T>>[] ToArray(int i)
        {
            if (i >= 0 && i < Count)
            {
                if (i >= TailOff()) return Tail;
                var node = this.Root;
                for (int level = this.Shift; level > 0; level -= 5)
                    node = (VectorNode<T>)node.Array[(i >> level) & 0x01f];
                return node.Array;
            }

            throw new ArgumentOutOfRangeException(nameof(i));
        }

        int TailOff() => Count < 32 ? 0 : ((Count - 1) >> 5) << 5;

        internal static VectorNode<T> NewPath(AtomicReference<Thread> edit, int level, VectorNode<T> node)
        {
            if (level == 0) return node;

            var ret = new VectorNode<T>(edit);
            ret.Array[0] = NewPath(edit, level - 5, node);
            return ret;
        }

        VectorNode<T> PushTail(int level, VectorNode<T> parent, VectorNode<T> tailNode)
        {
            // if parent is leaf, insert node,
            // else does it map to existing child?  -> nodeToInsert = pushNode one more level
            // else alloc new path
            // return nodeToInsert placed in copy of parent
            int subIdx = ((Count - 1) >> level) & 0x01f;
            var ret = new VectorNode<T>(parent.Edit, (UnionType<T, VectorNode<T>>[])parent.Array.Clone());
            VectorNode<T> nodeToInsert;

            if (level == 5)
                nodeToInsert = tailNode;
            else
            {
                var child = (VectorNode<T>)parent.Array[subIdx];
                nodeToInsert = (child != null
                                 ? PushTail(level - 5, child, tailNode)
                                 : NewPath(Root.Edit, level - 5, tailNode));
            }
            ret.Array[subIdx] = nodeToInsert;
            return ret;
        }

        VectorNode<T> PopTail(int level, VectorNode<T> node)
        {
            int subIdx = ((Count - 2) >> level) & 0x01f;
            if (level > 5)
            {
                var newChild = PopTail(level - 5, (VectorNode<T>)node.Array[subIdx]);
                if (newChild is null && subIdx == 0)
                    return null;
                else
                {
                    var ret = new VectorNode<T>(this.Root.Edit, (UnionType<T, VectorNode<T>>[])node.Array.Clone());
                    ret.Array[subIdx] = newChild;
                    return ret;
                }
            }
            else if (subIdx == 0) return null;
            else
            {
                var ret = new VectorNode<T>(this.Root.Edit, (UnionType<T, VectorNode<T>>[])node.Array.Clone());
                ret.Array[subIdx] = default;
                return ret;
            }
        }

        public T Reduce(Func<T, T, T> f)
        {
            T init;
            if (Count > 0) init = ToArray(0)[0];
            else
                throw new NotImplementedException("TODO"); // return funclib.Core.Invoke(f);

            int step = 0;
            for (int i = 0; i < Count; i += step)
            {
                var array = ToArray(i);
                for (int j = (i == 0 ? 1 : 0); j < array.Length; ++j)
                {
                    init = f(init, array[j]);
                }
                step = array.Length;
            }

            return init;
        }
        public TAccumulate Reduce<TAccumulate>(Func<TAccumulate, T, TAccumulate> f, TAccumulate init)
        {
            int step = 0;
            for (int i = 0; i < Count; i += step)
            {
                var array = ToArray(i);
                for (int j = 0; j < array.Length; ++j)
                {
                    init = f(init, array[j]);
                }
                step = array.Length;
            }

            return init;
        }
        public TResult ReduceKV<TResult>(Func<TResult, int, T, TResult> f, TResult init)
        {
            int step = 0;
            for (int i = 0; i < Count; i += step)
            {
                var array = ToArray(i);
                for (int j = 0; j < array.Length; j++)
                {
                    init = f(init, j + 1, array[j]);
                }
                step = array.Length;
            }

            return init;
        }
    }
}
