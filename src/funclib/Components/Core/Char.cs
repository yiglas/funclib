using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Coerce to char
    /// </summary>
    public class Char :
        IFunction<object, object>
    {
        /// <summary>
        /// Coerce to char
        /// </summary>
        /// <param name="x">The number to convert to a <see cref="char"/>.</param>
        /// <returns>
        /// Returns a <see cref="char"/> value.
        /// </returns>
        public object Invoke(object x) => Convert.ToChar(x);
    }
}
