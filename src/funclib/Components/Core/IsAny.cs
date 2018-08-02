using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> given any argument.
    /// </summary>
    public class IsAny :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> given any argument.
        /// </summary>
        /// <param name="x">Given argument.</param>
        /// <returns>
        /// Returns <see cref="true"/> given any argument.
        /// </returns>
        public object Invoke(object x) => true;
    }
}
