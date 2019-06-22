using funclib.Collections.Generic.Internal;
using System;

namespace funclib.Collections.Generic
{
    public abstract class ASeq<T> :
        IList<T>,
        ISeqable<T>
    {
        [NonSerialized]
        protected int _hash = 0;

        public bool IsReadOnly => true;

        #region Overrides
        public override string ToString() => Util.Print(this);

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is System.Collections.Generic.IList<T> list)) return false;

            var me = funclib.Generic.Core.Seq<T>(list);

            for (var e = Seq(); e != null; e = e.Next(), me = me.Next())
            {
                if (me is null || !e.First().Equals(me.First()))
                    return false;
            }

            return me is null;
        }

        public override int GetHashCode()
        {
            var hash = this._hash;
            if (hash == 0)
            {
                for (var e = Seq(); e != null; e = e.Next())
                    hash = 31 * hash + e.First().GetHashCode();

                this._hash = hash;
            }
            return hash;
        }
        #endregion

        #region Invalid Operations
        public void Add(T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        public void Insert(int index, T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        public bool Remove(T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        #endregion

        #region Abstract Methods
        public abstract UnionType<T, Nil> First();
        public abstract ISeq<T> Next();
        public abstract IStack<T> Pop();
        #endregion

        #region Virtual Methods
        public virtual ISeq<T> Cons(T o) => new Cons<T>(o, this);
        public virtual ISeq<T> More() => Next() ?? List<T>.EMPTY;
        public virtual int Count
        {
            get
            {
                int i = 1;
                for (var e = Next(); e != null; e = e.Next(), i++)
                {
                    if (e is ICounted c)
                    {
                        return i + c.Count;
                    }
                }

                return i;
            }
        }
        public virtual ICollection<T> Empty() => List<T>.EMPTY;
        public virtual int IndexOf(T item)
        {
            int i = 0;
            for (var e = Seq(); e != null; e = e.Next(), i++)
            {
                if (e.First() == item)
                {
                    return i;
                }
            }
            return -1;
        }
        public virtual System.Collections.Generic.IEnumerator<T> GetEnumerator() => new Enumerator<T>(this);
        public virtual UnionType<T, Nil> Peek() => First();
        public virtual ISeq<T> Seq()
        {
            if (Count == 0)
            {
                return null;
            }

            return this;
        }
        #endregion

        public UnionType<T, Nil> this[int index]
        {
            get
            {
                ISeq<T> e = this;
                for (int i = 0; i <= index && e != null; ++i, e = e.Next())
                {
                    if (i == index)
                    {
                        return e.First();
                    }
                }
                throw new IndexOutOfRangeException(nameof(index));
            }
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        }

        T System.Collections.Generic.IList<T>.this[int index]
        {
            get
            {
                var val = this[index];

                if (val != new Nil())
                {
                    return val.Item1;
                }

                return default; // TODO: maybe throw exception?
            }
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector<T>)}.");
        }

        public bool Contains(T item)
        {
           for (var e = Seq(); e != null; e = e.Next())
           {
                if (e.First() == item)
                {
                    return true;
                }
           }

            return false;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Must be no-negative.");
            if (array.Length - arrayIndex < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            var e = Seq();
            for (int i = arrayIndex; i < array.Length && e != null; ++i, e = e.Next())
            {
                array[i] = e.First();
            }
        }
        public void CopyTo(Array array, int index)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), "Must be no-negative.");
            if (array.Length - index < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            var e = Seq();
            for (int i = index; i < array.Length && e != null; ++i, e = e.Next())
            {
                array.SetValue(e.First(), i);
            }
        }

        ICollection<T> ICollection<T>.Cons(T o) => Cons(o);
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => new Enumerator<T>(this);
    }
}
