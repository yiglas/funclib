namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns true if object is bool and false or object is null.
        /// </summary>
        /// <param name="source">The <see cref="object"/> checking to is an object.</param>
        /// <returns>
        /// true if object is bool and false or null, otherwise false.
        /// </returns>
        public static bool falsy(object source)
        {
            if (source == null) return true;
            else if (source is bool && !(bool)source) return true;
            else return false;
        }
    }
}
