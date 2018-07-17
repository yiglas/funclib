using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if c <see cref="Type"/> is an instance of x, otherwise <see cref="false"/>.
    /// </summary>
    public class IsInstance :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if c <see cref="Type"/> is an instance of x, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="c">An <see cref="Type"/> object.</param>
        /// <param name="x">An object to check type of.</param>
        /// <returns>
        /// Returns <see cref="true"/> if c <see cref="Type"/> is an instance of x, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object c, object x) => ((Type)c).IsInstanceOfType(x);
    }
}
