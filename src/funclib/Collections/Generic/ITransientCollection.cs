namespace funclib.Collections.Generic
{
    public interface ITransientCollection<T>
    {
        int Count { get; }
        ITransientCollection<T> Conj(T val);
        ICollection<T> ToPersistent();
    }
}