namespace funclib.Collections
{
    public interface ICollection :
        ISeqable,
        System.Collections.ICollection,
        System.Collections.IEnumerable
    {
        new int Count { get; }
        ICollection Cons(object o);
        ICollection Empty();
    }
}
