using funclib.Components.Core.Generic;

namespace funclib.Collections.Generic
{
    public interface IReduce<T>
    {
        T Reduce(IFunction f);
        T Reduce(IFunction f, T init);
    }
}
