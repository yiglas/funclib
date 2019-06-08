namespace funclib.Collections.Generic.Internal
{
    interface ITransientVector<T> :
        ITransientAssociative<int, T>,
        ITransientCollection<T>,
        ICounted
    {
        new IVector<T> ToPersistent();
        new ITransientVector<T> Assoc(int i, T val);
        new ITransientVector<T> Conj(T val);

        T this[int index] { get; set; }
        T this[int index, T notFound] { get; set; }

        ITransientVector<T> Pop();
    }
}