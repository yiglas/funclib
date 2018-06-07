using FunctionalLibrary.Collections.Internal;
using FunctionalLibrary.Core;
using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public class LazySeq :
        ISeq,
        IPending,
        System.Collections.IList
    {
        IFunction<object> _fn;
        object _ev;
        ISeq _e;

        public int Count
        {
            get
            {
                int c = 0;
                for (var e = Seq(); e != null; e = e.Next())
                    ++c;
                return c;
            }
        }
        public bool IsSynchronized => true;
        public object SyncRoot => this;
        public bool IsReadOnly => true;
        public bool IsFixedSize => true;

        public object this[int index]
        {
            get
            {
                if (index < 0)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index must be non-negative");

                var e = Seq();
                for (int i = 0; e != null; e = e.Next(), i++)
                    if (i == index)
                        return e.First();

                throw new ArgumentOutOfRangeException(nameof(index), $"Index passed end of {nameof(LazySeq)}.");
            }
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        }

        public LazySeq(IFunction<object> fn)
        {
            this._fn = fn;
        }

        internal LazySeq(ISeq e)
        {
            this._fn = null;
            this._e = e;
        }

        #region Overrides
        public override int GetHashCode()
        {
            var e = Seq();
            if (e == null) return 1;
            return Util.GetHashCode(e);
        }

        public override bool Equals(object obj)
        {
            var e = Seq();
            if (e != null) return e.Equals(obj);
            return obj is System.Collections.IList && new Core.Seq().Invoke(obj) == null;
        }
        #endregion

        #region Invalid Operations
        public int Add(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        public void Insert(int index, object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        public void Remove(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        #endregion

        public ISeq Seq()
        {
            eval();
            if (this._ev != null)
            {
                var ls = this._ev;
                this._ev = null;
                while (ls is LazySeq l)
                    ls = l.eval();

                this._e = (ISeq)new Seq().Invoke(ls);
            }
            return this._e;
        }

        object eval()
        {
            if (this._fn != null)
            {
                this._ev = this._fn.Invoke();
                this._fn = null;
            }
            if (this._ev != null) return this._ev;

            return this._e;
        }

        public ISeq Cons(object o) => (ISeq)new Core.Cons().Invoke(o, Seq());
        public object First()
        {
            Seq();
            if (this._e == null) return null;
            return this._e.First();
        }
        public ISeq Next()
        {
            Seq();
            if (this._e == null) return null;
            return this._e.Next();
        }
        public ISeq More()
        {
            Seq();
            if (this._e == null) return List.EMPTY;
            return this._e.More();
        }
        ICollection ICollection.Cons(object o) => Cons(o);
        public ICollection Empty() => List.EMPTY;
        public void CopyTo(System.Array array, int index)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), "Must be no-negative.");
            if (array.Length - index < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            var e = Seq();
            for (int i = index; e != null; ++i, e = e.Next())
                array.SetValue(e.First(), i);
        }
        public void CopyTo(object[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Must be no-negative.");
            if (array.Length - arrayIndex < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            var e = Seq();
            for (int i = arrayIndex; e != null; ++i, e = e.Next())
                array[i] = e.First();
        }
        public bool Contains(object item)
        {
            for (var e = Seq(); e != null; e = e.Next())
                if (new Core.Equals().Invoke(e.First(), item))
                    return true;
            return false;
        }
        public System.Collections.IEnumerator GetEnumerator() => new Enumerator(this);
        public bool IsRealized() => this._fn == null;
        public int IndexOf(object value)
        {
            var e = Seq();
            for (int i = 0; e != null; e = e.Next(), i++)
                if (new Core.Equals().Invoke(e.First(), value))
                    return i;
            return -1;
        }
    }
}
