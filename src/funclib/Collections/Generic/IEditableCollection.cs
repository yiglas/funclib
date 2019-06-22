namespace funclib.Collections.Generic
{
    public interface IEditableCollection<T>
    {
        ITransientCollection<UnionType<T, Nil>> ToTransient();
    }
}