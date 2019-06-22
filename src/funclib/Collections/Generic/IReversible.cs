namespace funclib.Collections.Generic
{
    public interface IReversible<T>
    {
        ISeq<UnionType<T, Nil>> RSeq();
    }
}
