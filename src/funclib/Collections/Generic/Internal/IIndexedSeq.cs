namespace funclib.Collections.Generic.Internal
{
    interface IIndexedSeq<T> :
        ISeq<T>,
        ISequential
    {
        int Index();
    }
}
