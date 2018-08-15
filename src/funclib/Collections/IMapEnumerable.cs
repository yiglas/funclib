namespace funclib.Collections
{
    public interface IMapEnumerable
    {
        System.Collections.IEnumerator GetKeyEnumerator();
        System.Collections.IEnumerator GetValueEnumerator();
    }
}
