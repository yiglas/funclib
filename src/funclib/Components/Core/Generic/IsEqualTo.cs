using System;

namespace funclib.Components.Core.Generic
{

    public static partial class Stuff
    {
        public static bool IsEqualTo<T>(T x) => true;

        public static bool IsEqualTo<T1, T2>(T1 x, T2 y)
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

    public class IsEqualTo<T> :
        IFunction<T, bool>,
        IFunction<T, T, bool>
    {
        public bool Invoke(T x) => true;

        public bool Invoke(T x, T y)
        {
            if (x != null)
                x.Equals(y);

            return false;
        }
    }
}
