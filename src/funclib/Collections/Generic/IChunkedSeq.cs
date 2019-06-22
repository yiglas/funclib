namespace funclib.Collections.Generic
{
    public interface IChunkedSeq<T> :
        ISeq<T>,
        ISequential
    {
        IChunked<UnionType<T, Nil>> ChunkedFirst();
        ISeq<UnionType<T, Nil>> ChunkedNext();
        ISeq<UnionType<T, Nil>> ChunkedMore();
    }
}