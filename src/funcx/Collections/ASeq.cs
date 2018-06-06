using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    [Serializable]
    public abstract class ASeq :
        IList
    {
        [NonSerialized]
        protected int _hash = 0;

        public bool IsFixedSize => true;
        public bool IsReadOnly => true;
        public bool IsSynchronized => true;
        public object SyncRoot => this;

        #region Overrides
        public override string ToString() => base.ToString();  // TODO: implement to string method.

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is System.Collections.IList)) return false;

            var me = (ISeq)new Core.Seq().Invoke(obj);

            for (var e = Seq(); e != null; e = e.Next(), me = me.Next())
            {
                if (me == null || !new Core.Equals().Invoke(e.First(), me.First()))
                    return false;
            }

            return me == null;
        }

        public override int GetHashCode()
        {
            var hash = this._hash;
            if (hash == 0)
            {
                for (var e = Seq(); e != null; e = e.Next())
                    hash = 31 * hash + (e.First() == null ? 0 : e.First().GetHashCode());

                this._hash = hash;
            }
            return hash;
        }
        #endregion

        #region Invalid Operations
        public int Add(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq)}.");
        public void Insert(int index, object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq)}.");
        public void Remove(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq)}.");
        public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq)}.");
        void System.Collections.Generic.ICollection<object>.Add(object item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq)}.");
        bool System.Collections.Generic.ICollection<object>.Remove(object item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq)}.");
        #endregion

        #region Abstract Methods
        public abstract object First();
        public abstract ISeq Next();
        public abstract IStack Pop();
        #endregion

        #region Virtual Methods
        public virtual ISeq Cons(object o) => new Cons(o, this);
        public virtual ISeq More()
        {
            var s = Next();
            if (s == null) return List.EMPTY;
            return s;
        }
        public virtual int Count
        {
            get
            {
                int i = 1;
                for (var e = Next(); e != null; e = e.Next(), i++)
                {
                    if (e is System.Collections.ICollection c)
                        return i + c.Count;
                }

                return i;
            }
        }
        public virtual ICollection Empty() => List.EMPTY;
        public virtual int IndexOf(object value)
        {
            int i = 0;
            for (var e = Seq(); e != null; e = e.Next(), i++)
                if (new Core.Equals().Invoke(e.First(), value))
                    return i;
            return -1;
        }
        public virtual System.Collections.Generic.IEnumerator<object> GetEnumerator() => new Enumerator(this);
        #endregion

        public object this[int index]
        {
            get
            {
                ISeq e = this;
                for (int i = 0; i <= index && e != null; ++i, e = e.Next())
                {
                    if (i == index)
                        return e.First();
                }
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq)}.");
        }

        public bool Contains(object value)
        {
            for (var e = Seq(); e != null; e = e.Next())
                if (new Core.Equals().Invoke(e.First(), value))
                    return true;

            return false;
        }
        public void CopyTo(System.Array array, int index)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), "Must be no-negative.");
            if (array.Length - index < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            var e = Seq();
            for (int i = index; i < array.Length && e != null; ++i, e = e.Next())
                array.SetValue(e.First(), i);
        }
        public void CopyTo(object[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Must be no-negative.");
            if (array.Length - arrayIndex < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            var e = Seq();
            for (int i = arrayIndex; i < array.Length && e != null; ++i, e = e.Next())
                array[i] = e.First();
        }

        public ISeq Seq() => this;

        public object Peek() => First();
        ICollection ICollection.Cons(object o) => Cons(o);
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => new Enumerator(this);
    }
}
