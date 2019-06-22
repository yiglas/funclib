namespace funclib.Collections.Generic.Internal
{
    interface ITransientMap<TKey, TValue> :
        ITransientAssociative<TKey, TValue>,
        ITransientCollection<IKeyValuePair<TKey, TValue>>,
        ICounted
    {
        new IMap<UnionType<TKey, Nil>, UnionType<TValue, Nil>> ToPersistent();
        new int Count { get; }
        new ITransientMap<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Assoc(UnionType<TKey, Nil> key, UnionType<TValue, Nil> val);

        ITransientMap<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Without(UnionType<TKey, Nil> key);
    }
}