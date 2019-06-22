namespace funclib.Collections.Generic
{
    public interface IMapEnumerable<TKey, TValue>
    {
        System.Collections.Generic.IEnumerator<UnionType<TKey, Nil>> GetKeyEnumerator();
        System.Collections.Generic.IEnumerator<UnionType<TValue, Nil>> GetValueEnumerator();
    }
}