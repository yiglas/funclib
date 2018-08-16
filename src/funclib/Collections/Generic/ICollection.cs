namespace funclib.Collections.Generic
{
    public interface ICollection<T> :
        ISeqable<T>,
        System.Collections.Generic.ICollection<T>,
        System.Collections.Generic.IEnumerable<T>,
        System.Collections.IEnumerable
    {
        new int Count { get; }
        ICollection<T> Cons(T o);
        ICollection<T> Empty();
    }
}
