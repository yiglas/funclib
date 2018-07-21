using funclib.Collections.Internal;
using funclib.Components.Core;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Collections
{
    public abstract class AVector :
        IVector,
        IFunction<object, object>
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

            if (obj is IVector v)
            {
                if (v.Count != Count) return false;

                for (int i = 0; i < Count; i++)
                {
                    if (!(bool)new IsEqualTo().Invoke(this[i], v[i]))
                        return false;
                }

                return true;
            }

            if (obj is IList l)
            {
                if (l.Count != Count) return false;

                for (int i = 0; i < Count; i++)
                {
                    if (!(bool)new IsEqualTo().Invoke(this[i], l[i]))
                        return false;
                }

                return true;
            }

            if (obj is ISeq e)
            {
                for (int i = 0; i < Count; i++, e = e.Next())
                {
                    if (e == null || !(bool)new IsEqualTo().Invoke(this[i], e.First()))
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
                    hash = 31 * hash + (obj == null ? 0 : obj.GetHashCode());
                }
                this._hash = hash;
            }
            return hash;
        }
        #endregion

        #region Invalid Operations
        public int Add(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        public void Insert(int index, object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        public void Remove(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        #endregion

        #region Abstract Methods
        public abstract object this[int index] { get; set; }
        public abstract int Count { get; }
        public abstract IVector Assoc(int i, object val);
        public abstract IVector Cons(object o);
        public abstract ICollection Empty();
        public abstract IStack Pop();
        public abstract ITransientCollection ToTransient();
        #endregion

        #region Virtual Methods
        public virtual object this[int index, object notFound]
        {
            get
            {
                if (index >= 0 && index < Count)
                    return this[index];
                return notFound;
            }
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AVector)}.");
        }
        public virtual bool ContainsKey(object key) => int.TryParse(key.ToString(), out int i) && i >= 0 && i < Count;
        public virtual IKeyValuePair Get(object key) =>
            int.TryParse(key.ToString(), out int i) && i >= 0 && i < Count
                ? new KeyValuePair(i, this[i])
                : null;
        public virtual System.Collections.IEnumerator GetEnumerator()
        {
            for (var e = Seq(); e != null; e = e.Next())
            {
                yield return e.First();
            }
        }
        public virtual object GetValue(object key) => GetValue(key, null);
        public virtual object GetValue(object key, object notFound) =>
            int.TryParse(key.ToString(), out int i) && i >= 0 && i < Count
                ? this[i]
                : notFound;
        public virtual ISeq Seq() => Count > 0 ? new VectorSeq(this, 0) : null;
        public virtual ISeq RSeq() => Count > 0 ? new VectorRSeq(this, Count - 1) : null;
        public virtual object Peek() => Count > 0 ? this[Count - 1] : null;
        public virtual System.Collections.IEnumerator RangedEnumerator(int start, int end)
        {
            for (int i = start; i < end; i++)
                yield return this[i];
        }
        #endregion

        #region Functions
        public object Invoke(object index) => GetValue(index, null);
        #endregion


        public IAssociative Assoc(object key, object val) =>
            int.TryParse(key.ToString(), out int i)
                ? Assoc(i, val)
                : this;
        public bool Contains(object value)
        {
            for (var e = Seq(); e != null; e = e.Next())
                if ((bool)new IsEqualTo().Invoke(e.First(), value))
                    return true;

            return false;
        }
        public void CopyTo(System.Array array, int index)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), "Must be no-negative.");
            if (array.Length - index < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            if (Count == 0) return;

            for (int i = 0; i < Count; i++)
                array.SetValue(this[i], i + index);
        }
        public void CopyTo(object[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Must be no-negative.");
            if (array.Length - arrayIndex < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            if (Count == 0) return;

            for (int i = 0; i < Count; i++)
                array[i + arrayIndex] = this[i];
        }
        public int IndexOf(object value)
        {
            for (int i = 0; i < Count; i++)
                if ((bool)new IsEqualTo().Invoke(this[i], value))
                    return i;

            return -1;
        }
        ICollection ICollection.Cons(object o) => Cons(o);
        public int CompareTo(object obj)
        {
            if (obj is IVector v)
            {
                if (Count < v.Count) return -1;
                if (Count > v.Count) return 1;

                for (int i = 0; i < Count; i++)
                {
                    var c = (int)compare(this[i], v[i]);
                    if (c != 0)
                        return c;
                }

                return 0;
            }

            return 1;
        }
    }
}
