namespace funclib.Collections.Generic.Internal
{
    interface ITransientAssociative<TKey, TValue> :
        ITransientCollection<IKeyValuePair<TKey, TValue>>,
        IGetValue<TKey, TValue>
    {
        bool ContainsKey(TKey key);
        ITransientAssociative<TKey, TValue> Assoc(TKey key, TValue val);
        IKeyValuePair<TKey, TValue> Get(TKey key);
    }
}
