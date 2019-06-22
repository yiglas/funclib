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
        new IVector<UnionType<T, Nil>> Cons(UnionType<T, Nil> o);
        new IVector<UnionType<T, Nil>> Assoc(UnionType<int, Nil> i, UnionType<T, Nil> val);
        new ISeq<UnionType<T, Nil>> Seq();
        new System.Collections.Generic.IEnumerator<UnionType<T, Nil>> GetEnumerator();
        new UnionType<T, Nil> this[int index] { get; set; }

        UnionType<UnionType<T, Nil>, Nil> this[int index, UnionType<T, Nil> notFound] { get; set; }
    }
}
