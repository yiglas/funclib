using funclib.Collections.Generic;

namespace funclib.Components.Core.Generic
{
    public class List<T> :
        IFunctionParams<T, IList<T>>
    {
        public IList<T> Invoke(params T[] items) => Collections.Generic.List<T>.Create(items);
    }
}
