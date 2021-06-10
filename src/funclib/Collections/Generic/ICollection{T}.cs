namespace funclib.Collections
{
    public interface ICollection<T> :
        ISeqable<T>,
        System.Collections.ICollection,
        System.Collections.Generic.ICollection<T>,
        System.Collections.IEnumerable,
        System.Collections.Generic.IEnumerable<T>
    {
        new int Count { get; }

        ICollection<T> Cons(T o);
        ICollection<T> Empty();
    }
}
