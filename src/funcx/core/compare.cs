namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        public static int compare<T>(T x, T y)
        {
            if (x.Equals(y)) return 0;
            if (y == null) return 1;
            if (x is string sx)
            {
                return sx.CompareTo(y);
            }
            if (x is int ix)
            {
                return ix.CompareTo(y);
            }
            if (x is double dx)
            {
                return dx.CompareTo(y);
            }
            if (x is float fx)
            {
                return fx.CompareTo(y);
            }
            if (x is IDictionary)
            {

            }
            if (x is IList ex)
            {
                var ey = y as IList;
                
                for (int i = 0; i < ex.Count; i++)                
                {
                    int r = 0;

                    if (ex[i] is IComparable exc)
                    {
                        r = exc.CompareTo(ey[i]);
                    }
                    else
                        throw new NotSupportedException($"Cannot compare {ex[i]} to {ey[i]}");

                    if (r != 0) return r;
                }

                return 0;
            }

            return -1;
        }
    }
}
