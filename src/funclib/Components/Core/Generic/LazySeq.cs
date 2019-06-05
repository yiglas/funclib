using funclib.Collections.Generic;
using funclib.Collections.Generic.Internal;
using System;

namespace funclib.Components.Core.Generic
{
    public class LazySeq<T> :
        IMacroFunction<ISeq<T>>,
        ISeq<T>,
        Collections.IPending,
        Collections.ISequential,
        System.Collections.Generic.IList<T>
    {
        IFunction<T> _fn;
        T _sv;
        ISeq<T> _s;

        public int Count
        {
            get
            {
                int c = 0;
                for (var e = Seq(); e != null; e = e.Next())
                {
                    ++c;
                }
                return c;
            }
        }

        public bool IsReadOnly => true;
        public object SyncRoot => this;
        public bool IsSynchronized => true;
        public bool IsFixedSize => true;

        public T this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index must be non-negative");
                }

                var e = Seq();
                for (int i = 0; e != null; e = e.Next(), i++)
                {
                    if (i == index)
                    {
                        return e.First();
                    }
                }

                throw new ArgumentOutOfRangeException(nameof(index), $"Index passed end of {nameof(LazySeq)}.");
            }
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        }

        public LazySeq() :
            this(() => default)
        { }

        public LazySeq(Func<T> fn) :
            this(funclib.Generic.Core.Func(fn))
        { }

        public LazySeq(IFunction<T> fn)
        {
            this._fn = fn;
        }

        public LazySeq(T body) :
            this(() => body)
        { }

        internal LazySeq(ISeq<T> e)
        {
            this._fn = null;
            this._s = e;
        }

        #region Overrides
        public override int GetHashCode()
        {
            var e = Seq();
            if (e is null) return 1;
            return Util.GetHashCode(e);
        }

        public override bool Equals(object obj)
        {
            var e = Seq();
            if (e != null) return e.Equals(obj);
            return obj is System.Collections.Generic.IList<T> && funclib.Generic.Core.Seq(obj) is null;
        }
        #endregion

        #region Invalid Operations
        public void Add(T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        public void Insert(int index, T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        public bool Remove(T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        #endregion

        public ISeq<T> Seq()
        {
            eval();
            if (this._sv != null)
            {
                var ls = this._sv;
                this._sv = default;
                while (ls is LazySeq<T> l)
                {
                    ls = l.eval();
                }

                this._s = funclib.Generic.Core.Seq(ls);
            }
            return this._s;
        }

        UnionType<T, ISeq<T>> eval()
        {
            if (this._fn != null)
            {
                this._sv = this._fn.Invoke();
                this._fn = null;
            }

            if (this._sv != null)
            {
                return this._sv;
            }

            return UnionType<T, ISeq<T>>.Create(this._s);
        }

        public ISeq<T> Cons(T o) => funclib.Generic.Core.Cons(o);
        public T First()
        {
            Seq();
            if (this._s is null)
            {
                return default;
            }
            return this._s.First();
        }
        public ISeq<T> Next()
        {
            Seq();
            if (this._s is null)
            {
                return null;
            }
            return this._s.Next();
        }
        public ISeq<T> More()
        {
            Seq();
            if (this._s is null)
            {
                return Collections.Generic.List<T>.EMPTY;
            }
            return this._s.More();
        }
        Collections.Generic.ICollection<T> Collections.Generic.ICollection<T>.Cons(T o) => Cons(o);
        public Collections.Generic.ICollection<T> Empty() => Collections.Generic.List<T>.EMPTY;
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Must be no-negative.");
            if (array.Length - arrayIndex < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            var e = Seq();
            for (int i = arrayIndex; e != null; ++i, e = e.Next())
            {
                array[i] = e.First();
            }
        }
        public bool Contains(T item)
        {
            for (var e = Seq(); e != null; e = e.Next())
            {
                if (funclib.Generic.Core.IsEqualTo(e.First(), item))
                {
                    return true;
                }
            }

            return false;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator() => new Enumerator<T>(this);

        public int IndexOf(T item)
        {
            var e = Seq();
            for (int i = 0; e != null; e = e.Next(), i++)
            {
                if (funclib.Core.E(e.First(), item))
                {
                    return i;
                }
            }
            return -1;
        }

        #region Functions
        public ISeq<T> Invoke() => Seq();
        #endregion

        public bool IsRealized() => this._fn is null;

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
