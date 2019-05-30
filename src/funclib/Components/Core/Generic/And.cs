using System.Linq;

namespace funclib.Components.Core.Generic
{
    public class And :
        IFunction<bool>
    {
        public bool Invoke() => true;
    }

    public class And<T> :
        IFunction<T, T>,
        IFunctionParams<T, T, T>
    {
        public T Invoke(T x) => x;

        public T Invoke(T x, params T[] next)
        {
            if (Stuff.Truthy(x) && (next?.Length ?? 0) > 0)
            {
                return Invoke(next[0], next.Skip(1).ToArray());
            }

            return x;
        }
    }
}
