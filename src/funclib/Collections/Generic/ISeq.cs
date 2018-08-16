namespace funclib.Collections.Generic
{
    public interface ISeq<T> :
        ICollection<T>,
        System.Collections.Generic.IEnumerable<T>
    {
        new ISeq<T> Cons(T o);

        T First();
        ISeq<T> Next();
        ISeq<T> More();
    }
}
