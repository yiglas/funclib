namespace funclib.Collections.Generic.Internal
{
    interface ITransientVector<T> :
        ITransientAssociative<int, T>,
        ICounted
    {
        new IVector<T> ToPersistent();
        new ITransientVector<T> Assoc(int i, T val);
        ITransientVector<T> Conj(T val);

        T this[int index] { get; set; }
        T this[int index, T notFound] { get; set; }

        ITransientVector<T> Pop();
    }
}