namespace funclib.Collections.Generic
{
    public interface IMap<TKey, TValue> :
        IAssociative<TKey, TValue>,
        ICollection<IKeyValuePair<TKey, TValue>>,
        IEditableCollection<IKeyValuePair<TKey, TValue>>,
        IMapEnumerable<TKey, TValue>,
        ICounted,
        System.Collections.Generic.IDictionary<TKey, TValue>,
        System.Collections.Generic.IEnumerable<IKeyValuePair<TKey, TValue>>
    {
        new bool ContainsKey(TKey key);
        new int Count { get; }
        new IMap<TKey, TValue> Assoc(TKey key, TValue val);
        new IMap<TKey, TValue> Cons(IKeyValuePair<TKey, TValue> o);

        IMap<TKey, TValue> Without(TKey key);
    }
}