using funclib.Collections;
using funclib.Collections.Internal;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Takes a body of expressions that returns an <see cref="ISeq"/> or <see cref="null"/>, and 
    /// yields a <see cref="ISeqable"/> object that will invoke the body only the first time <see cref="LazySeq.Seq"/>
    /// is called, and will cache the result and return it on all subsequent <see cref="LazySeq.Seq"/> calls.
    /// </summary>
    public class LazySeq :
        IMacroFunction,
        ISeq,
        IPending,
        ISequential,
        System.Collections.IList        
    {
        IFunction<object> _fn;
        object _sv;
        ISeq _s;

        /// <summary>
        /// Returns the count of items, evaluated and caching each item as it counts.
        /// </summary>
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
        /// <summary>
        /// Returns true.
        /// </summary>
        public bool IsSynchronized => true;
        /// <summary>
        /// Returns this.
        /// </summary>
        public object SyncRoot => this;
        /// <summary>
        /// Returns true.
        /// </summary>
        public bool IsReadOnly => true;
        /// <summary>
        /// Returns true.
        /// </summary>
        public bool IsFixedSize => true;

        /// <summary>
        /// Indexer, evaluates and caches each item until it hits the indexer value and returns it.
        /// </summary>
        /// <param name="index">The item to retrieve.</param>
        /// <returns>
        /// Returns the object at the indexer point.
        /// </returns>
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

        /// <summary>
        /// Creates an empty <see cref="LazySeq"/> that yields null.
        /// </summary>
        public LazySeq() :
            this(() => null)
        { }

        /// <summary>
        /// Creates a <see cref="LazySeq"/> with the fn as its body.
        /// </summary>
        /// <param name="fn">A function to evaluate during each <see cref="LazySeq.Seq"/> call.</param>
        public LazySeq(Func<object> fn) :
            this(func(fn))
        { }

        /// <summary>
        /// Creates a <see cref="LazySeq"/> with the fn as its body.
        /// </summary>
        /// <param name="fn">A function to evaluate during each <see cref="LazySeq.Seq"/> call.</param>
        public LazySeq(IFunction<object> fn)
        {
            this._fn = fn;
        }

        /// <summary>
        /// Creates a <see cref="LazySeq"/> with the fn returning the object as its body.
        /// </summary>
        /// <param name="body">The object to return when <see cref="LazySeq.Seq"/> is called.</param>
        public LazySeq(object body) :
            this(() => body)
        { }

        /// <summary>
        /// Creates a <see cref="LazySeq"/> with the items of the sequence.
        /// </summary>
        /// <param name="e">The sequence of items.</param>
        internal LazySeq(ISeq e)
        {
            this._fn = null;
            this._s = e;
        }

        #region Overrides
        /// <summary>
        /// Gets the hash code for the <see cref="LazySeq"/>.
        /// </summary>
        /// <returns>
        /// Returns the hash code for the <see cref="LazySeq"/>.
        /// </returns>
        public override int GetHashCode()
        {
            var e = Seq();
            if (e is null) return 1;
            return Util.GetHashCode(e);
        }

        /// <summary>
        /// Determine the equality between this <see cref="LazySeq"/> and the object.
        /// </summary>
        /// <param name="obj">An object to test its equality against.</param>
        /// <returns>
        /// Returns <see cref="true"/> of objects are equal, otherwise <see cref="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var e = Seq();
            if (e != null) return e.Equals(obj);
            return obj is System.Collections.IList && seq(obj) is null;
        }
        #endregion

        #region Invalid Operations
        public int Add(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        public void Insert(int index, object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        public void Remove(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LazySeq)}.");
        #endregion

        /// <summary>
        /// Evaluates the item.
        /// </summary>
        /// <returns>
        /// Returns the <see cref="ISeq"/> object calls.
        /// </returns>
        public ISeq Seq()
        {
            eval();
            if (this._sv != null)
            {
                var ls = this._sv;
                this._sv = null;
                while (ls is LazySeq l)
                    ls = l.eval();

                this._s = (ISeq)seq(ls);
            }
            return this._s;
        }

        object eval()
        {
            if (this._fn != null)
            {
                this._sv = this._fn.Invoke();
                this._fn = null;
            }
            if (this._sv != null) return this._sv;

            return this._s;
        }

        /// <summary>
        /// Adds object to the <see cref="LazySeq"/>.
        /// </summary>
        /// <param name="o">Object to add.</param>
        /// <returns>
        /// Returns the <see cref="ISeq"/> object calls.
        /// </returns>
        public ISeq Cons(object o) => (ISeq)cons(o, Seq());
        /// <summary>
        /// Returns the first object in the <see cref="LazySeq"/>.
        /// </summary>
        /// <returns>
        /// Returns the first object in the <see cref="LazySeq"/>.
        /// </returns>
        public object First()
        {
            Seq();
            if (this._s is null) return null;
            return this._s.First();
        }
        /// <summary>
        /// Returns the rest of the objects in the <see cref="LazySeq"/>. If the 
        /// result of <see cref="LazySeq"/> is null, return null.
        /// </summary>
        /// <returns>
        /// Returns the rest of the objects in the <see cref="LazySeq"/>. If the 
        /// result of <see cref="LazySeq"/> is null, return null.
        /// </returns>
        public ISeq Next()
        {
            Seq();
            if (this._s is null) return null;
            return this._s.Next();
        }
        /// <summary>
        /// Returns the rest of the objects in the <see cref="LazySeq"/>. If the 
        /// result of <see cref="LazySeq"/> is null, return <see cref="Collections.List.EMPTY"/>.
        /// </summary>
        /// <returns>
        /// Returns the rest of the objects in the <see cref="LazySeq"/>. If the 
        /// result of <see cref="LazySeq"/> is null, return <see cref="Collections.List.EMPTY"/>.
        /// </returns>
        public ISeq More()
        {
            Seq();
            if (this._s is null) return Collections.List.EMPTY;
            return this._s.More();
        }
        ICollection ICollection.Cons(object o) => Cons(o);
        /// <summary>
        /// Returns a <see cref="Collections.List.EMPTY"/>.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="Collections.List.EMPTY"/>.
        /// </returns>
        public ICollection Empty() => Collections.List.EMPTY;
        public void CopyTo(System.Array array, int index)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), "Must be no-negative.");
            if (array.Length - index < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            var e = Seq();
            for (int i = index; e != null; ++i, e = e.Next())
                array.SetValue(e.First(), i);
        }
        public void CopyTo(object[] array, int arrayIndex)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
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
                if ((bool)isEqualTo(e.First(), item))
                    return true;
            return false;
        }
        public System.Collections.IEnumerator GetEnumerator() => new Enumerator(this);
        public bool IsRealized() => this._fn is null;
        public int IndexOf(object value)
        {
            var e = Seq();
            for (int i = 0; e != null; e = e.Next(), i++)
                if ((bool)isEqualTo(e.First(), value))
                    return i;
            return -1;
        }

        /// <summary>
        /// Calls the <see cref="LazySeq.Seq"/> function.
        /// </summary>
        /// <returns>
        /// Returns the result of calling <see cref="LazySeq.Seq"/>.
        /// </returns>
        public object Invoke() => Seq();
    }
}