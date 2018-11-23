namespace funclib.Components.Core.Generic
{
    public class Truthy<T> :
        IFunction<T, bool>
    {
        public bool Invoke(T source) => !funclib.Generic.Core.Falsy(source);
    }
}