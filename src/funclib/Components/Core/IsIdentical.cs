using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is identical to y, otherwise <see cref="false"/>.
    /// </summary>
    public class IsIdentical :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is identical to y, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">First object.</param>
        /// <param name="y">Object to test against.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is identical to y, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x, object y) =>
            x is ValueType
                ? x.Equals(y)
                : x == y;
    }
}
