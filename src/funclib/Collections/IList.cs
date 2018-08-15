namespace funclib.Collections
{
    public interface IList : 
        IStack,
        ISeq,
        ICollection,
        ICounted,
        ISequential,
        System.Collections.IList,
        System.Collections.ICollection,
        System.Collections.IEnumerable
    {
        new object this[int index] { get; set; }
        new int Count { get; }
    }
}
