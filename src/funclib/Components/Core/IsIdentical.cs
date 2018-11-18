using funclib.Components.Core.Generic;
using System;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is identical to y, otherwise false.
    /// </summary>
    public class IsIdentical :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns true if x is identical to y, otherwise false.
        /// </summary>
        /// <param name="x">First object.</param>
        /// <param name="y">Object to test against.</param>
        /// <returns>
        /// Returns true if x is identical to y, otherwise false.
        /// </returns>
        public object Invoke(object x, object y) =>
            x is ValueType
                ? x.Equals(y)
                : x == y;
    }
}
