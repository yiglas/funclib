using System;

namespace funclib.Components.Core.Generic
{
    public class IsEqualTo<T> :
        IFunction<T, bool>,
        IFunction<T, T, bool>
    {
        public bool Invoke(T x) => true;
        public bool Invoke(T x, T y) => throw new NotImplementedException();
    }
}
