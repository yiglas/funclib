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
        new bool ContainsKey(UnionType<TKey, Nil> key);
        new int Count { get; }
        new IMap<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Assoc(UnionType<TKey, Nil> key, UnionType<TValue, Nil> val);
        new IMap<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Cons(IKeyValuePair<UnionType<TKey, Nil>, UnionType<TValue, Nil>> o);

        IMap<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Without(UnionType<TKey, Nil> key);
    }
}