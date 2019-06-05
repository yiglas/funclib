namespace funclib.Collections.Generic
{
    public interface IAssociative<TKey, TValue> :
        ICollection<IKeyValuePair<TKey, TValue>>,
        IGetValue<TKey, TValue>
    {
        bool ContainsKey(TKey key);
        IAssociative<TKey, TValue> Assoc(TKey key, TValue val);
        IKeyValuePair<TKey, TValue> Get(TKey key);
    }
}