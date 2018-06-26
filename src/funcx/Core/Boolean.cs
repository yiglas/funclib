using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// If x is a boolean return x, otherwise return x != null.
    /// </summary>
    public class Boolean :
        IFunction<object, object>
    {
        /// <summary>
        /// If x is a boolean return x, otherwise return x != null.
        /// </summary>
        /// <param name="x">Object to coerce into a boolean.</param>
        /// <returns>
        /// Returns x if it's a boolean, otherwise return x != null.
        /// </returns>
        public object Invoke(object x) =>
            x is bool b
                ? b
                : x != null;
    }
}
