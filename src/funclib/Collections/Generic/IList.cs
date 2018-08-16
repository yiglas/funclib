namespace funclib.Collections.Generic
{
    public interface IList<T> :
        IStack<T>,
        ISeq<T>,
        ICollection<T>,
        ICounted,
        ISequential,
        System.Collections.Generic.IList<T>,
        System.Collections.Generic.ICollection<T>,
        System.Collections.Generic.IEnumerable<T>,
        System.Collections.IEnumerable
    {
        new T this[int index] { get; set; }
        new int Count { get; }
    }
}
