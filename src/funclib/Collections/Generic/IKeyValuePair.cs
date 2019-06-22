namespace funclib.Collections.Generic
{
    public interface IKeyValuePair<TKey, TValue>
    {
        UnionType<TKey, Nil> Key { get; }
        UnionType<TValue, Nil> Value { get; }
    }
}