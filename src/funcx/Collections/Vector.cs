using FunctionalLibrary.Collections.Internal;
using FunctionalLibrary.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FunctionalLibrary.Collections
{
    public class Vector :
        AVector,
        IReduce,
        IReduceKV
    {
        static readonly AtomicReference<Thread> NoEdit = new AtomicReference<Thread>();
        internal static readonly VectorNode EmptyNode = new VectorNode(NoEdit, new object[32]);
        public static readonly IVector EMPTY = new Vector(0, 5, EmptyNode, new object[32]);

        internal int Shift { get; }
        internal VectorNode Root { get; }
        internal object[] Tail { get; }

        public override int Count { get; }
        public override object this[int index]
        {
            get => ToArray(index)[index & 0x01f];
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Vector)}.");
        }

        internal Vector(int count, int shift, VectorNode root, object[] tail)
        {
            Count = count;
            Shift = shift;
            Root = root;
            Tail = tail;
        }

        #region Creates
        public static Vector Create(ISeq init)
        {
            var arr = new object[32];
            int i = 0;
            for (; init != null && i < 32; init = init.Next())
                arr[i++] = init.First();

            if (init != null)
            {
                var start = new Vector(32, 5, EmptyNode, arr);
                var ret = start.ToTransient();
                for (; init != null; init = init.Next())
                    ret = ret.Conj(init.First());

                return ret.ToPersistent() as Vector;
            }
            else if (i == 32)
                return new Vector(32, 5, EmptyNode, arr);
            else
            {
                var arr2 = new object[i];
                System.Array.Copy(arr, 0, arr2, 0, i);

                return new Vector(i, 5, EmptyNode, arr2);
            }
        }

        public static Vector Create(params object[] init)
        {
            var ret = EMPTY.ToTransient();
            foreach (var item in init)
                ret = ret.Conj(item);

            return ret.ToPersistent() as Vector;
        }
        #endregion

        #region Overrides
        public override IVector Assoc(int i, object val)
        {
            if (i >= 0 && i < Count)
            {
                if (i >= TailOff())
                {
                    var newTail = new object[this.Tail.Length];
                    System.Array.Copy(this.Tail, newTail, this.Tail.Length);
                    newTail[i & 0x01f] = val;

                    return new Vector(Count, this.Shift, this.Root, newTail);
                }

                return new Vector(Count, this.Shift, assoc(this.Shift, this.Root, i, val), this.Tail);
            }

            if (i == Count) return Cons(val);

            throw new ArgumentOutOfRangeException(nameof(i));

            VectorNode assoc(int level, VectorNode node, int idx, object value)
            {
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
        public override IVector Cons(object o)
        {
            if (Count - TailOff() < 32)
            {
                var newTail = new object[this.Tail.Length + 1];
                System.Array.Copy(this.Tail, newTail, this.Tail.Length);
                newTail[this.Tail.Length] = o;
                return new Vector(Count + 1, this.Shift, this.Root, newTail);
            }

            VectorNode newRoot;
            var tailNode = new VectorNode(this.Root.Edit, this.Tail);
            int newShift = this.Shift;

            if ((Count >> 5) > (1 << this.Shift))
            {
                newRoot = new VectorNode(this.Root.Edit);
                newRoot.Array[0] = this.Root;
                newRoot.Array[1] = NewPath(this.Root.Edit, this.Shift, tailNode);
                newShift += 5;
            }
            else newRoot = PushTail(this.Shift, this.Root, tailNode);

            return new Vector(Count + 1, newShift, newRoot, new object[] { o });
        }
        public override ICollection Empty() => EMPTY;
        public override IStack Pop()
        {
            if (Count == 0) throw new InvalidOperationException($"Cannot pop an empty {nameof(Vector)}.");
            if (Count == 1) return EMPTY;

            object[] newTail;

            if (Count - TailOff() > 1)
            {
                newTail = new object[this.Tail.Length - 1];
                System.Array.Copy(this.Tail, newTail, newTail.Length);
                return new Vector(Count - 1, this.Shift, this.Root, newTail);
            }

            newTail = ToArray(Count - 2);
            var newRoot = PopTail(this.Shift, this.Root);
            int newShift = this.Shift;

            if (newRoot == null) newRoot = EmptyNode;
            if (this.Shift > 5 && newRoot.Array[1] == null)
            {
                newRoot = (VectorNode)newRoot.Array[0];
                newShift -= 5;
            }

            return new Vector(Count - 1, newShift, newRoot, newTail);
        }
        public override ISeq Seq() => Count == 0 ? null : new ChunkedSeq(this, 0, 0);
        public override ITransientCollection ToTransient() => new TransientVector(this);
        public override IEnumerator<object> GetEnumerator() => RangedEnumerator(0, Count);
        public override IEnumerator<object> RangedEnumerator(int start, int end)
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
        
        internal object[] ToArray(int i)
        {
            if (i >= 0 && i < Count)
            {
                if (i >= TailOff()) return Tail;
                var node = this.Root;
                for (int level = this.Shift; level > 0; level -= 5)
                    node = (VectorNode)node.Array[(i >> level) & 0x01f];
                return node.Array;
            }

            throw new ArgumentOutOfRangeException(nameof(i));
        }

        int TailOff() => Count < 32 ? 0 : ((Count - 1) >> 5) << 5;

        internal static VectorNode NewPath(AtomicReference<Thread> edit, int level, VectorNode node)
        {
            if (level == 0) return node;

            var ret = new VectorNode(edit);
            ret.Array[0] = NewPath(edit, level - 5, node);
            return ret;
        }

        VectorNode PushTail(int level, VectorNode parent, VectorNode tailNode)
        {
            // if parent is leaf, insert node,
            // else does it map to existing child?  -> nodeToInsert = pushNode one more level
            // else alloc new path
            // return nodeToInsert placed in copy of parent
            int subIdx = ((Count - 1) >> level) & 0x01f;
            var ret = new VectorNode(parent.Edit, (object[])parent.Array.Clone());
            VectorNode nodeToInsert;

            if (level == 5)
                nodeToInsert = tailNode;
            else
            {
                var child = (VectorNode)parent.Array[subIdx];
                nodeToInsert = (child != null
                                 ? PushTail(level - 5, child, tailNode)
                                 : NewPath(Root.Edit, level - 5, tailNode));
            }
            ret.Array[subIdx] = nodeToInsert;
            return ret;
        }

        VectorNode PopTail(int level, VectorNode node)
        {
            int subIdx = ((Count - 2) >> level) & 0x01f;
            if (level > 5)
            {
                var newChild = PopTail(level - 5, (VectorNode)node.Array[subIdx]);
                if (newChild == null && subIdx == 0)
                    return null;
                else
                {
                    var ret = new VectorNode(this.Root.Edit, (object[])node.Array.Clone());
                    ret.Array[subIdx] = newChild;
                    return ret;
                }
            }
            else if (subIdx == 0) return null;
            else
            {
                var ret = new VectorNode(this.Root.Edit, (object[])node.Array.Clone());
                ret.Array[subIdx] = null;
                return ret;
            }
        }

        public object Reduce(IFunction<object, object, object> f)
        {
            object init;
            if (Count > 0) init = ToArray(0)[0];
            else
                return f.Invoke(null, null);

            int step = 0;
            for (int i = 0; i < Count; i += step)
            {
                var array = ToArray(i);
                for (int j = (i == 0 ? 1 : 0); i < array.Length; ++j)
                {
                    init = f.Invoke(init, array[j]);
                    if ((bool)new IsReduced().Invoke(init))
                        return ((IDeref)init).Deref();
                }
                step = array.Length;
            }

            return init;
        }
        public object Reduce(IFunction<object, object, object> f, object init)
        {
            int step = 0;
            for (int i = 0; i < Count; i += step)
            {
                var array = ToArray(i);
                for (int j = 0; j < array.Length; ++j)
                {
                    init = f.Invoke(init, array[j]);
                    if ((bool)new IsReduced().Invoke(init))
                        return ((IDeref)init).Deref();
                }
                step = array.Length;
            }

            return init;
        }
        public object Reduce(IFunction<object, object, object, object> f, object init)
        {
            int step = 0;
            for (int i = 0; i < Count; i += step)
            {
                var array = ToArray(i);
                for (int j = 0; j < array.Length; j++)
                {
                    init = f.Invoke(init, j + 1, array[j]);
                    if ((bool)new IsReduced().Invoke(init))
                        return ((IDeref)init).Deref();
                }
                step = array.Length;
            }

            return init;
        }
    }
}
