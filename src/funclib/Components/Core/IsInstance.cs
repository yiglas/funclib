using funclib.Components.Core.Generic;
using System;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if c <see cref="Type"/> is an instance of x, otherwise false.
    /// </summary>
    public class IsInstance :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns true if c <see cref="Type"/> is an instance of x, otherwise false.
        /// </summary>
        /// <param name="c">An <see cref="Type"/> object.</param>
        /// <param name="x">An object to check type of.</param>
        /// <returns>
        /// Returns true if c <see cref="Type"/> is an instance of x, otherwise false.
        /// </returns>
        public object Invoke(object c, object x) => ((Type)c).IsInstanceOfType(x);
    }
}
