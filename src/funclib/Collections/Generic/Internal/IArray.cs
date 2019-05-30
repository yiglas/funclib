namespace funclib.Collections.Generic.Internal
{
    interface IArray<T> :
        ISeq<T>,
        IIndexedSeq<T>
        System.Collections.Generic.IList<T>
    {
        T[] ToArray();
        T[] Array();
    }
}