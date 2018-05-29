using funcx.Collections.Internal;
using funcx.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace funcx.Collections
{
    public class Vector :
        EnumerativeVector
    {
        public static readonly IVector EMPTY = new Vector(0, 5, EmptyNode, new object[0]);
        static readonly AtomicReference<Thread> NoEdit = new AtomicReference<Thread>();
        internal static readonly VectorNode EmptyNode = new VectorNode(NoEdit, new object[32]);

        int _hash;
        internal int Shift { get; }
        internal VectorNode Root { get; }
        internal object[] Tail { get; }

        public override int Count { get; }
        public override object this[int index] { get => ToArray(index)[index & 0x01f]; set => throw new NotImplementedException(); }

        internal Vector(int count, int shift, VectorNode root, object[] tail)
        {
            Count = count;
            Shift = shift;
            Root = root;
            Tail = tail;
        }

        #region Creates
        public static Vector Create(IEnumerative init)
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
                Array.Copy(arr, 0, arr2, 0, i);

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
                    Array.Copy(this.Tail, newTail, this.Tail.Length);
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
                Array.Copy(this.Tail, newTail, this.Tail.Length);
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
                Array.Copy(this.Tail, newTail, newTail.Length);
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
        public override IEnumerative Enumerate() => Count == 0 ? null : new ChunkedEnumerative(this, 0, 0);
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

        //#region Overrides
        //public override string ToString() => base.ToString(); // TODO: implement to string method.

        //public override bool Equals(object obj)
        //{
        //    if (this == obj) return true;

        //    if (obj is IVector v)
        //    {
        //        if (v.Count != Count) return false;

        //        for (int i = 0; i < Count; i++)
        //        {
        //            if (!Util.IsEqual(this[i], v[i]))
        //                return false;
        //        }

        //        return true;
        //    }

        //    if (obj is IList l)
        //    {
        //        if (l.Count != Count) return false;

        //        for (int i = 0; i < Count; i++)
        //        {
        //            if (!Util.IsEqual(this[i], l[i]))
        //                return false;
        //        }

        //        return true;
        //    }

        //    if (obj is IEnumerative e)
        //    {
        //        for (int i = 0; i < Count; i++, e = e.Next())
        //        {
        //            if (e == null || !Util.IsEqual(this[i], e.First()))
        //                return false;
        //        }
        //        if (e != null) return false;

        //        return true;
        //    }

        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    int hash = this._hash;
        //    if (hash == 0)
        //    {
        //        hash = 1;
        //        for (int i = 0; i < Count; i++)
        //        {
        //            var obj = this[i];
        //            hash = 31 * hash + (obj == null ? 0 : obj.GetHashCode());
        //        }
        //        this._hash = hash;
        //    }
        //    return hash;
        //}
        //#endregion

        //#region Invalid Operations
        //public void Add(object item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Vector)}.");
        //public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Vector)}.");
        //public bool Remove(object item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Vector)}.");
        //int System.Collections.IList.Add(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Vector)}.");
        //public void Insert(int index, object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Vector)}.");
        //void System.Collections.IList.Remove(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Vector)}.");
        //public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Vector)}.");
        //#endregion

        //#region Functions
        //public object Invoke(object index) => GetValue(index);
        //#endregion

        //#region Virtual Methods
        //public virtual object this[int index] {
        //    get => ToArray(index)[index & 0x01f];
        //    set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Vector)}."); }
        //public virtual object this[int index, object notFound] {
        //    get => index >= 0 && index < Count ? this[index] : notFound;
        //    set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Vector)}."); }
        //public virtual IAssociative Assoc(object key, object val) =>
        //    int.TryParse(key.ToString(), out int i)
        //        ? Assoc(i, val)
        //        : this;
        //public virtual object GetValue(object key) => GetValue(key, null);
        //public virtual object GetValue(object key, object notFound) =>
        //    int.TryParse(key.ToString(), out int i) && i >= 0 && i < Count
        //        ? this[i]
        //        : notFound;
        //public virtual bool ContainsKey(object key) => int.TryParse(key.ToString(), out int i) && i >= 0 && i < Count;
        //public virtual KeyValuePair<int, object>? Get(object key) =>
        //    int.TryParse(key.ToString(), out int i)
        //        ? (KeyValuePair<int, object>?)new KeyValuePair<int, object>(i, this[i])
        //        : null;
        //public virtual object Peek() => Count > 0 ? this[Count - 1] : null;
        //public virtual IStack Pop()
        //{
        //    if (Count == 0) throw new InvalidOperationException($"Cannot pop an empty {nameof(Vector)}.");
        //    if (Count == 1) return EMPTY;

        //    object[] newTail;

        //    if (Count - TailOff() > 1)
        //    {
        //        newTail = new object[this.Tail.Length - 1];
        //        Array.Copy(this.Tail, newTail, newTail.Length);
        //        return new Vector(Count - 1, this.Shift, this.Root, newTail);
        //    }

        //    newTail = ToArray(Count - 2);
        //    var newRoot = PopTail(this.Shift, this.Root);
        //    int newShift = this.Shift;

        //    if (newRoot == null) newRoot = EmptyNode;
        //    if (this.Shift > 5 && newRoot.Array[1] == null)
        //    {
        //        newRoot = (VectorNode)newRoot.Array[0];
        //        newShift -= 5;
        //    }

        //    return new Vector(Count - 1, newShift, newRoot, newTail);
        //}
        //public virtual IVector Assoc(int i, object val)
        //{
        //    if (i >= 0 && i < Count)
        //    {
        //        if (i >= TailOff())
        //        {
        //            var newTail = new object[this.Tail.Length];
        //            Array.Copy(this.Tail, newTail, this.Tail.Length);
        //            newTail[i & 0x01f] = val;

        //            return new Vector(Count, this.Shift, this.Root, newTail);
        //        }

        //        return new Vector(Count, this.Shift, assoc(this.Shift, this.Root, i, val), this.Tail);
        //    }

        //    if (i == Count) return Cons(val);

        //    throw new ArgumentOutOfRangeException(nameof(i));

        //    VectorNode assoc(int level, VectorNode node, int idx, object value)
        //    {
        //        var ret = new VectorNode(node.Edit, (object[])node.Array.Clone());
        //        if (level == 0)
        //            ret.Array[idx & 0x01f] = value;
        //        else
        //        {
        //            int subIdx = (idx >> level) & 0x01f;
        //            ret.Array[subIdx] = assoc(level - 5, (VectorNode)node.Array[subIdx], idx, value);
        //        }

        //        return ret;
        //    }
        //}
        //public virtual IVector Cons(object o)
        //{
        //    if (Count - TailOff() < 32)
        //    {
        //        var newTail = new object[this.Tail.Length + 1];
        //        Array.Copy(this.Tail, newTail, this.Tail.Length);
        //        newTail[this.Tail.Length] = o;
        //        return new Vector(Count + 1, this.Shift, this.Root, newTail);
        //    }

        //    VectorNode newRoot;
        //    var tailNode = new VectorNode(this.Root.Edit, this.Tail);
        //    int newShift = this.Shift;

        //    if ((Count >> 5) > (1 << this.Shift))
        //    {
        //        newRoot = new VectorNode(this.Root.Edit);
        //        newRoot.Array[0] = this.Root;
        //        newRoot.Array[1] = NewPath(this.Root.Edit, this.Shift, tailNode);
        //        newShift += 5;
        //    }
        //    else newRoot = PushTail(this.Shift, this.Root, tailNode);

        //    return new Vector(Count + 1, newShift, newRoot, new object[] { o });
        //}
        //public virtual IEnumerator<object> GetEnumerator() => RangedEnumerator(0, Count);

        //public virtual IEnumerator<object> RangedEnumerator(int start, int end)
        //{
        //    int i = start;
        //    int b = i - (i % 32);
        //    var arr = start < Count ? ToArray(i) : null;

        //    while (i < end)
        //    {
        //        if (i - b == 32)
        //        {
        //            arr = ToArray(i);
        //            b += 32;
        //        }
        //        yield return arr[i++ & 0x01f];
        //    }
        //}
        //public virtual IEnumerative Enumerate() => Count == 0 ? null : new ChunkedEnumerative(this, 0, 0);
        //public virtual ICollection Empty() => EMPTY;
        //#endregion


        //public bool Contains(object item)
        //{
        //    for (int i = 0; i < Count; i++)
        //    {
        //        if (Util.IsEqual(this[i], item))
        //            return true;
        //    }

        //    return false;
        //}

        //public void CopyTo(Array array, int index)
        //{
        //    if (array == null) throw new ArgumentNullException(nameof(array));
        //    if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
        //    if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), "Must be no-negative.");
        //    if (array.Length - index < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

        //    if (Count == 0) return;

        //    for (int i = 0; i < Count; i++)
        //        array.SetValue(this[i], i + index);
        //}
        //public void CopyTo(object[] array, int arrayIndex)
        //{
        //    if (array == null) throw new ArgumentNullException(nameof(array));
        //    if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
        //    if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Must be no-negative.");
        //    if (array.Length - arrayIndex < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

        //    if (Count == 0) return;

        //    for (int i = 0; i < Count; i++)
        //        array[i + arrayIndex] = this[i];
        //}


        //public ITransientCollection ToTransient() => new TransientVector(this);
        //ICollection ICollection.Cons(object o) => Cons(o);
        //KeyValuePair<object, object>? IAssociative.Get(object key)
        //{
        //    var kvp = Get(key);
        //    return kvp.HasValue
        //        ? (KeyValuePair<object, object>?)new KeyValuePair<object, object>(kvp.Value.Key, kvp.Value.Value)
        //        : null;
        //}

        //IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //public int IndexOf(object value)
        //{
        //    for (int i = 0; i < Count; i++)
        //    {
        //        if (Util.IsEqual(this[i], value))
        //            return i;
        //    }

        //    return -1;
        //}


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

    }
}
