namespace funclib.Collections.Generic
{
    public interface IGetValue<TKey, TValue>
    {
        TValue GetValue(TKey key);
        TValue GetValue(TKey key, TValue notFound);
    }
}