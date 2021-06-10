namespace funclib.Collections
{
    public interface IStack<T> :
        ICollection<T>
    {
        T Peek();
        IStack<T> Pop();
    }
}
