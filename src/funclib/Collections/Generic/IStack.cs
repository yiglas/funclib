namespace funclib.Collections.Generic
{
    public interface IStack<T> :
        ICollection<T>
    {
        T Peek();
        IStack<T> Pop();
    }
}
