namespace funclib.Collections.Generic
{
    public interface IGetValue<TKey, TValue>
    {
        UnionType<TValue, Nil> GetValue(UnionType<TKey, Nil> key);
        UnionType<TValue, Nil> GetValue(UnionType<TKey, Nil> key, UnionType<TValue, Nil> notFound);
    }
}