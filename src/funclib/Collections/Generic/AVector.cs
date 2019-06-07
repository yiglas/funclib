using funclib.Collections.Generic.Internal;
using funclib.Components.Core.Generic;
using System;

namespace funclib.Collections.Generic
{
    public abstract class AVector<T> :
        IVector<T>,
        IFunction<int, T>
    {
        int _hash;

        public bool IsFixedSize => true;
        public bool IsReadOnly => true;
        public bool IsSynchronized => true;
        public object SyncRoot => this;

        #region Overrides
        public override string ToString() => Util.Print(this);

        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            if (obj is IVector<T> v)
            {
                if (v.Count != Count) return false;

                for (int i = 0; i < Count; i++)
                {
                    if (!funclib.Generic.Core.IsEqualTo(this[i], v[i]))
                    {
                        return false;
                    }
                }

                return true;
            }

            if (obj is IList<T> l)
            {
                if (l.Count != Count) return false;

                for (int i = 0; i < Count; i++)
                {
                    if (!funclib.Generic.Core.IsEqualTo(this[i], l[i]))
                        return false;
                }

                return true;
            }

            if (obj is ISeq<T> e)
            {
                for (int i = 0; i < Count; i++, e = e.Next())
                {
                    if (e is null || !funclib.Generic.Core.IsEqualTo(this[i], e.First()))
                        return false;
                }
                if (e != null) return false;

                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = this._hash;
            if (hash == 0)
            {
                hash = 1;
                for (int i = 0; i < Count; i++)
                {
                    var obj = this[i];
                    hash = 31 * hash + (obj is object ? obj.GetHashCode() : 0);
                }
                this._hash = hash;
            }
            return hash;
        }
        #endregion

        #region Invalid Operations
        public void Add(IKeyValuePair<int, T> item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        public void Add(T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        public void Insert(int index, T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        public bool Remove(IKeyValuePair<int, T> item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        public bool Remove(T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        #endregion

        #region Abstract Methods
        public abstract T this[int index] { get; set; }
        public abstract int Count { get; }
        public abstract IVector<T> Assoc(int i, T val);
        public abstract IVector<T> Cons(T o);
        public abstract IVector<T> Empty();
        public abstract IStack<T> Pop();
        // public abstract ITransientCollection<T> ToTransient();
        #endregion

        #region Virtual Methods
        public virtual T this[int index, T notFound]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return this[index];
                }

                return notFound;
            }
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        }
        public virtual bool ContainsKey(int key) => key >= 0 && key < Count;
        public virtual IKeyValuePair<int, T> Get(int key)
        {
            if (key >= 0 && key < Count)
            {
                return new KeyValuePair<int, T>(key, this[key]);
            }

            return null;
        }

        public virtual System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            for (var e = Seq(); e != null; e = e.Next())
            {
                yield return e.First();
            }
        }
        public virtual T GetValue(int key) => GetValue(key, default);
        public virtual T GetValue(int key, T notFound)
        {
            if (key >= 0 && key < Count)
            {
                return this[key];
            }

            return notFound;
        }

        public virtual T Peek() => Count > 0 ? this[Count - 1] : default;
        public virtual ISeq<T> Seq() => Count > 0 ? new VectorSeq<T>(this, 0) : default;
        public virtual ISeq<T> RSeq() => Count > 0 ? new VectorRSeq<T>(this, Count - 1) : default;
        public virtual System.Collections.Generic.IEnumerator<T> RangedEnumerator(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                yield return this[i];
            }
        }
        #endregion

        #region Functions
        public T Invoke(int index) => GetValue(index);
        #endregion

        public int CompareTo(object obj)
        {
            if (obj is IVector<T> v)
            {
                if (Count < v.Count) return -1;
                if (Count > v.Count) return 1;

                for (int i = 0; i < Count; i++)
                {
                    var c = funclib.Generic.Core.Compare(this[i], v[i]);
                    if (c != 0)
                        return c;
                }

                return 0;
            }

            return 1;
        }

        public ICollection<IKeyValuePair<int, T>> Cons(IKeyValuePair<int, T> o) => Cons(o.Value);

        public bool Contains(IKeyValuePair<int, T> item) => Contains(item.Value);

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

        public void CopyTo(IKeyValuePair<int, T>[] array, int arrayIndex)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Must be no-negative.");
            if (array.Length - arrayIndex < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            if (Count == 0) return;

            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = new KeyValuePair<int, T>(i, this[i]);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Must be no-negative.");
            if (array.Length - arrayIndex < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            if (Count == 0) return;

            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = this[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (funclib.Generic.Core.IsEqualTo(this[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        IAssociative<int, T> IAssociative<int, T>.Assoc(int key, T val) => Assoc(key, val);

        ICollection<T> ICollection<T>.Cons(T o) => Cons(o);

        ICollection<IKeyValuePair<int, T>> ICollection<IKeyValuePair<int, T>>.Empty() => Empty();

        ICollection<T> ICollection<T>.Empty() => Empty();

        System.Collections.Generic.IEnumerator<IKeyValuePair<int, T>> System.Collections.Generic.IEnumerable<IKeyValuePair<int, T>>.GetEnumerator()
        {
            int i = -1;
            for (var e = Seq(); e != null; e = e.Next())
            {
                yield return new KeyValuePair<int, T>(++i, e.First());
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        ISeq<IKeyValuePair<int, T>> ISeqable<IKeyValuePair<int, T>>.Seq()
        {
            throw new NotImplementedException();
        }
    }
}
