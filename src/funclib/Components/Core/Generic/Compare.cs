using System;

namespace funclib.Components.Core.Generic
{
    public partial class Stuff
    {
        public static int Compare<T>(T x, T y)
        {
            if (IsEqualTo(x, y)) return 0;
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