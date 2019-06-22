namespace funclib.Collections.Generic
{
    public interface IStack<T> :
        ICollection<T>
    {
        UnionType<T, Nil> Peek();
        IStack<UnionType<T, Nil>> Pop();
    }
}
