using System;
using System.Collections;
using System.Collections.Generic;

namespace funclib.Collections.Generic
{
    //public abstract class ASeq<T> :
    //    IList<T>,
    //    ISeqable<T>
    //{
    //    protected int _hash = 0;

    //    public bool IsReadOnly => true;
    //    public bool IsSynchronized => true;
    //    public object SyncRoot => this;

    //    #region Overrides
    //    public override string ToString()
    //    {
    //        return Util.Print(this);
    //    }

    //    public override bool Equals(object obj)
    //    {
    //        if (this == obj) return true;
    //        if (!(obj is System.Collections.IList)) return false;

    //        // TODO: implement equals
    //        throw new NotImplementedException();
    //    }
    //    public override int GetHashCode()
    //    {
    //        //TODO: implement get hash code
    //        throw new NotImplementedException();
    //    }
    //    #endregion

    //    #region Invalid Operations
    //    public void Add(T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
    //    public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
    //    public void Insert(int index, T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
    //    public bool Remove(T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
    //    public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
    //    #endregion

    //    #region Abstract Methods
    //    public abstract T First();
    //    public abstract ISeq<T> Next();
    //    public abstract IStack<T> Pop();
    //    #endregion

    //    #region Virtual Methods
    //    public virtual ISeq<T> Cons(T o)
    //    {
    //        return new Cons<T>(o, this);
    //    }

    //    public virtual ISeq<T> More()
    //    {
    //        var s = Next();

    //        if (s is null)
    //        {
    //            return List<T>.EMPTY;
    //        }

    //        return s;
    //    }

    //    public virtual int Count
    //    {
    //        get
    //        {
    //            int i = 1;

    //            for (var s = Next(); s != null; s = s.Next(), i++)
    //            {
    //                if (s is ICounted c)
    //                {
    //                    return i + c.Count;
    //                }
    //            }

    //            return i;
    //        }
    //    }

    //    public virtual ICollection<T> Empty()
    //    {
    //        return List<T>.EMPTY;
    //    }


    //    public virtual int IndexOf(T item)
    //    {
    //        int i = 0;

    //        for (var s = Seq(); s != null; s.Next(), i++)
    //        {
    //            if (funclib.Generic.Core.IsEqualTo<T>(s.First(), item))
    //            {
    //                return i;
    //            }
    //        }

    //        return -1;
    //    }

    //    public virtual IEnumerator<T> GetEnumerator()
    //    {
    //        return new Enumerator<T>(this);
    //    }

    //    public virtual T Peek()
    //    {
    //        return First();
    //    }

    //    public virtual ISeq<T> Seq()
    //    {
    //        if (Count == 0)
    //        {
    //            return null;
    //        }

    //        return this;
    //    }

    //    #endregion

    //    public T this[int index]
    //    {
    //        get
    //        {
    //             ISeq<T> s = this;

    //             for (int i = 0; i <= index && s != null; ++i, s = s.Next())
    //             {
    //                 if (i == index)
    //                 {
    //                     return s.First();
    //                 }
    //             }

    //             throw new IndexOutOfRangeException(nameof(index));
    //        }
    //        set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
    //    }

    //    public bool Contains(T item)
    //    {
    //        for (var s = Seq(); s != null; s = s.Next())
    //        {
    //            if (funclib.Generic.Core.IsEqualTo(s.First(), item))
    //            {
    //                return true;
    //            }
    //        }

    //        return false;
    //    }

    //    public void CopyTo(Array array, int index)
    //    {
    //        if (array is null) throw new ArgumentNullException(nameof(array));
    //        if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
    //        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), "Must be no-negative.");
    //        if (array.Length - index < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

    //        var s = Seq();

    //        for (int i = index; i < array.Length && s != null; ++i, s = s.Next())
    //        {
    //            array.SetValue(s.First(), i);
    //        }
    //    }

    //    public void CopyTo(T[] array, int arrayIndex)
    //    {
    //        if (array is null) throw new ArgumentNullException(nameof(array));
    //        if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
    //        if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Must be no-negative.");
    //        if (array.Length - arrayIndex < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

    //        var s = Seq();

    //        for (int i = arrayIndex; i < array.Length && s != null; ++i, s = s.Next())
    //        {
    //            array[i] = s.First();
    //        }
    //    }

    //    ICollection<T> ICollection<T>.Cons(T o)
    //    {
    //        return Cons(o);
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }
    //}
}
