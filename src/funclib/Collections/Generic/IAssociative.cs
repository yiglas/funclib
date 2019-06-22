namespace funclib.Collections.Generic
{
    public interface IAssociative<TKey, TValue> :
        ICollection<IKeyValuePair<TKey, TValue>>,
        IGetValue<TKey, TValue>
    {
        bool ContainsKey(UnionType<TKey, Nil> key);
        IAssociative<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Assoc(UnionType<TKey, Nil> key, UnionType<TValue, Nil> val);
        IKeyValuePair<UnionType<TKey, UnionType<TValue, Nil>>, TValue> Get(UnionType<TKey, Nil> key);
    }
}