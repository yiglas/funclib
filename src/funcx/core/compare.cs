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
            if (double.TryParse(Convert.ToString(x, CultureInfo.InvariantCulture), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out double nx))
            {
                return nx.CompareTo(y);
            }
            if (x is IDictionary)
            {

            }
            if (x is IList ex)
            {
                var ey = y as IList;
                
                if (ex.Count != ey.Count)
                    return -1
                
            }

            return -1;
        }
    }
}
