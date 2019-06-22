namespace funclib.Collections.Generic
{
    public interface ITransientCollection<T>
    {
        int Count { get; }
        ITransientCollection<UnionType<T, Nil>> Conj(UnionType<T, Nil> val);
        ICollection<UnionType<T, Nil>> ToPersistent();
    }
}