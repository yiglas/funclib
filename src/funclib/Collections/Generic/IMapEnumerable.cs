namespace funclib.Collections.Generic
{
    public interface IMapEnumerable<TKey, TValue>
    {
        System.Collections.Generic.IEnumerator<TKey> GetKeyEnumerator();
        System.Collections.Generic.IEnumerator<TValue> GetValueEnumerator();
    }
}