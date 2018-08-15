namespace funclib.Collections.Internal
{
    interface IIndexedSeq :
        ISeq,
        ISequential
    {
        int Index();
    }
}
