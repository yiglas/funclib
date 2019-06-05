namespace funclib.Collections.Generic
{
    public interface IChunkedSeq<T> :
        ISeq<T>,
        ISequential
    {
        IChunked<T> ChunkedFirst();
        ISeq<T> ChunkedNext();
        ISeq<T> ChunkedMore();
    }
}