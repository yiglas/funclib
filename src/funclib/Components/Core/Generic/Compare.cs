using System;

namespace funclib.Components.Core.Generic
{
    public class Compare<T> :
        IFunction<T, T, int>
    {
        public int Invoke(T x, T y)
        {
            if (funclib.Generic.Core.IsEqualTo(x, y)) return 0;
            if (x is object)
            {
                if (!(y is object)) return 1;
                if (Numbers.IsNumber(x) && Numbers.IsNumber(y))
                    return Numbers.Compare(x, y);

                return ((IComparable)x).CompareTo(y);
            }

            return -1;
        }
    }
}
