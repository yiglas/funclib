namespace funclib.Collections
{
    public interface IReduce
    {
        object Reduce(object f);
        object Reduce(object f, object init);
    }
}
