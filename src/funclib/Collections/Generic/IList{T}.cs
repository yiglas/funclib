namespace funclib.Collections
{
    public interface IList<T> :
        IStack<T>,
        ISeq<T>,
        ICollection<T>,
        ICounted,
        ISequential,
        System.Collections.Generic.IList<T>,
        System.Collections.Generic.ICollection<T>,
        System.Collections.IEnumerable,
        System.Collections.Generic.IEnumerable<T>
    {
        new T this[int index] { get; set; }
        new int Count { get; }
    }
}
