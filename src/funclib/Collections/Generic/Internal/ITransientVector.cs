namespace funclib.Collections.Generic.Internal
{
    interface ITransientVector<T> :
        ITransientAssociative<int, T>,
        ITransientCollection<T>,
        ICounted
    {
        new IVector<UnionType<T, Nil>> ToPersistent();
        new ITransientVector<UnionType<T, Nil>> Assoc(UnionType<int, Nil> i, UnionType<T, Nil> val);
        new ITransientVector<UnionType<T, Nil>> Conj(UnionType<T, Nil> val);

        UnionType<T, Nil> this[int index] { get; set; }
        UnionType<T, Nil> this[int index, UnionType<T, Nil> notFound] { get; set; }

        ITransientVector<UnionType<T, Nil>> Pop();
    }
}