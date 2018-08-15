namespace funclib.Collections
{
    public interface ISeq :
        ICollection,
        System.Collections.IEnumerable
    {
        new ISeq Cons(object o);

        object First();
        ISeq Next();
        ISeq More();
    }
}
