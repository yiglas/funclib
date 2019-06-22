namespace funclib.Collections.Generic
{
    public interface ICollection<T> :
        ISeqable<T>,
        System.Collections.Generic.ICollection<T>,
        System.Collections.Generic.IEnumerable<T>,
        System.Collections.IEnumerable
    {
        new int Count { get; }
        ICollection<UnionType<T, Nil>> Cons(UnionType<T, Nil> o);
        ICollection<UnionType<T, Nil>> Empty();
    }
}
