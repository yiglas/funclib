namespace funclib.Collections.Generic
{
    public interface IEditableCollection<TValue>
    {
        ITransientCollection<TValue> ToTransient();
    }
}