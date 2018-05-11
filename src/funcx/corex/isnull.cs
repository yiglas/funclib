namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns true if x is null
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// true if x is null, otherwise false.
        /// </returns>
        public static bool isnull<T>(T x) => x == null;
    }
}
