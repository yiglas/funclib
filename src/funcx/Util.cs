namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using _ = funcx.core;

    static class Util
    {
        internal static R Reduce1<T, R>(Func<R, T, R> f, IEnumerable<T> coll)
        {
            if (_.truthy(coll))
            {
                return Reduce1(f, (R)Convert.ChangeType(_.first(coll), typeof(R)), _.next(coll));
            }

            return default(R);
        }

        internal static R Reduce1<T, R>(Func<R, T, R> f, R val, IEnumerable<T> coll)
        {
            if (_.truthy(coll))
            {
                return Reduce1(f, f(val, _.first(coll)), _.next(coll));
            }

            return val;
        }

        internal static bool IsNumeric(object x)
        {
            if (x == null)
                return false;

            double number;
            return Double.TryParse(Convert.ToString(x, CultureInfo.InvariantCulture), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);
        }
    }
}
