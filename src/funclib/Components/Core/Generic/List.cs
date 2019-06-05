namespace funclib.Components.Core.Generic
{
    public class List<T> :
        IFunctionParams<T, Collections.Generic.List<T>>
    {
        public Collections.Generic.List<T> Invoke(params T[] items) => Collections.Generic.List<T>.Create(items) as Collections.Generic.List<T>;
    }
}
