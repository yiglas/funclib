namespace funclib.Collections
{
    public interface ISet :
        ICollection,
        IEditableCollection,
        ICounted,
        System.Collections.ICollection
    {
        new int Count { get; }

        bool Contains(object key);
        ISet Disj(object key);
        object Get(object key);
    }
}
