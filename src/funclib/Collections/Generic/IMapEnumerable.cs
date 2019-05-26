namespace funclib.Collections.Generic
{
    public interface IMapEnumerable<TKey, TValue>
    {
        System.Collections.Generic.IEnumerable<TKey> GetKeyEnumerator();
        System.Collections.Generic.IEnumerable<TValue> GetValueEnumerator();
    }
}