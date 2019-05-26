namespace funclib.Collections.Generic
{
    public interface ITransientCollection<TValue>
    {
        int Count { get; }
        ITransientCollection<TValue> Conj(TValue val);
        ICollection<TValue> ToPersistent();
    }
}