using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// If x is a <see cref="bool"/> return x, otherwise return x != null.
    /// </summary>
    public class Boolean :
        IFunction<object, object>
    {
        /// <summary>
        /// If x is a <see cref="bool"/> return x, otherwise return x != null.
        /// </summary>
        /// <param name="x">Object to coerce into a boolean.</param>
        /// <returns>
        /// Returns a <see cref="bool"/> that indicates either the value of x if its a boolean, otherwise the result of x != null.
        /// </returns>
        public object Invoke(object x) =>
            x is bool b
                ? b
                : x != null;
    }
}
