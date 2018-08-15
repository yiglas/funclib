namespace funclib.Collections
{
    public interface ITransientCollection
    {
        int Count { get; }
        ITransientCollection Conj(object val);
        ICollection ToPersistent();
    }
}
