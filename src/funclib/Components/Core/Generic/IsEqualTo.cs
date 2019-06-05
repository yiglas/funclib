using System;

namespace funclib.Components.Core.Generic
{
    public class IsEqualTo<T> :
        IFunction<T, bool>,
        IFunction<T, T, bool>
    {
        public bool Invoke(T x) => true;

        public bool Invoke(T x, T y)
        {
             if (x is object)
            {
                if (x.Equals(y)) return true;

                if (Numbers.IsNumber(x) && Numbers.IsNumber(y))
                {
                    return Numbers.IsEqual(x, y);
                }
            }

            return false;
        }
    }
}
