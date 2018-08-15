namespace funclib.Collections.Internal
{
    interface IArray :
        ISeq,
        IIndexedSeq,
        System.Collections.IList
    {
        object[] ToArray();
        object Array();
    }
}
