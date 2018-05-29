using funcx.Collections.Internal;
using System;
using System.Text;

namespace funcx.Collections
{
    [Serializable]
    public abstract class Enumerative :
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

            var me = new Core.Enumerate().Invoke(obj);

            for (var e = Enumerate(); e != null; e = e.Next(), me = me.Next())
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
                for (var e = Enumerate(); e != null; e = e.Next())
                    hash = 31 * hash + (e.First() == null ? 0 : e.First().GetHashCode());

                this._hash = hash;
            }
            return hash;
        }
        #endregion

        #region Invalid Operations
        public int Add(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Enumerative)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Enumerative)}.");
        public void Insert(int index, object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Enumerative)}.");
        public void Remove(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Enumerative)}.");
        public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Enumerative)}.");
        void System.Collections.Generic.ICollection<object>.Add(object item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Enumerative)}.");
        bool System.Collections.Generic.ICollection<object>.Remove(object item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Enumerative)}.");
        #endregion

        #region Abstract Methods
        public abstract object First();
        public abstract IEnumerative Next();
        public abstract IStack Pop();
        #endregion

        #region Virtual Methods
        public virtual IEnumerative Cons(object o) => throw new NotImplementedException();
        public virtual IEnumerative More()
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
            for (var e = Enumerate(); e != null; e = e.Next(), i++)
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
                IEnumerative e = this;
                for (int i = 0; i <= index && e != null; ++i, e = e.Next())
                {
                    if (i == index)
                        return e.First();
                }
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Enumerative)}.");
        }

        public bool Contains(object value)
        {
            for (var e = Enumerate(); e != null; e = e.Next())
                if (new Core.Equals().Invoke(e.First(), value))
                    return true;

            return false;
        }
        public void CopyTo(Array array, int index)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), "Must be no-negative.");
            if (array.Length - index < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            var e = Enumerate();
            for (int i = index; i < array.Length && e != null; ++i, e = e.Next())
                array.SetValue(e.First(), i);
        }
        public void CopyTo(object[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Must be no-negative.");
            if (array.Length - arrayIndex < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            var e = Enumerate();
            for (int i = arrayIndex; i < array.Length && e != null; ++i, e = e.Next())
                array[i] = e.First();
        }

        public IEnumerative Enumerate() => this;

        public object Peek() => First();
        ICollection ICollection.Cons(object o) => Cons(o);
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => new Enumerator(this);
    }
}
