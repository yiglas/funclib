using System;
using funclib.Collections.Generic.Internal;

namespace funclib.Collections.Generic
{
    public interface IVector<T>:
        IAssociative<int, T>,
        ICollection<T>,
        IEditableCollection<T>,
        IStack<T>,
        ICounted,
        IReversible<T>,
        IComparable,
        ISequential,
        System.Collections.Generic.IList<T>,
        System.Collections.Generic.IEnumerable<T>
    {
        new int Count { get; }
        new IVector<T> Cons(T o);
        new IVector<T> Assoc(int i, T val);
        new ISeq<T> Seq();
        new System.Collections.Generic.IEnumerator<T> GetEnumerator();
        new T this[int index] { get; set; }

        T this[int index, T notFound] { get; set; }
    }
}
