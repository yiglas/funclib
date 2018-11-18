using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is a number, otherwise false.
    /// </summary>
    public class IsNumber :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a number, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is a number, otherwise false.
        /// </returns>
        public object Invoke(object x) => Numbers.IsNumber(x);
    }
}
