namespace funclib.Collections.Generic.Internal
{
    interface ITransientAssociative<TKey, TValue> :
        ITransientCollection<IKeyValuePair<TKey, TValue>>,
        IGetValue<TKey, TValue>
    {
        bool ContainsKey(UnionType<TKey, Nil> key);
        ITransientAssociative<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Assoc(UnionType<TKey, Nil> key, UnionType<TValue, Nil> val);
        IKeyValuePair<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Get(UnionType<TKey, Nil> key);
    }
}
