namespace funclib.Collections.Generic
{
    public interface IKeyValuePair<TKey, TValue>
    {
        TKey Key { get; }
        TValue Value { get; }
    }
}