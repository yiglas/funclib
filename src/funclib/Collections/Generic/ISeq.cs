using TNil = funclib.UnionType<T, funclib.Nil>;

namespace funclib.Collections.Generic
{
    public interface ISeq<T> :
        ICollection<T>,
        System.Collections.Generic.IEnumerable<T>
    {
        new ISeq<UnionType<T, Nil>> Cons(T o);

        UnionType<T, Nil> First();
        ISeq<UnionType<T, Nil>> Next();
        ISeq<UnionType<T, Nil>> More();
    }
}
