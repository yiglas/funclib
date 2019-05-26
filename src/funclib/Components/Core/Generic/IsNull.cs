using System.Collections.Generic;

namespace funclib.Components.Core.Generic
{
    public class IsNull<T> :
        IFunction<T, bool>
    {
        public static bool Invoke(T x) => EqualityComparer<T>.Default.Equals(x, default);
    }
}
