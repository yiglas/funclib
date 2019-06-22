namespace funclib.Collections.Generic
{
    public interface ISeqable<T>
    {
        ISeq<UnionType<T, Nil>> Seq();
    }
}
