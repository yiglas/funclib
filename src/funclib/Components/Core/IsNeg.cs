using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is less than zero, otherwise false.
    /// </summary>
    public class IsNeg :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is less than zero, otherwise false.
        /// </summary>
        /// <param name="num">Object to test.</param>
        /// <returns>
        /// Returns true if x is less than zero, otherwise false.
        /// </returns>
        public object Invoke(object num) => Numbers.IsNeg(num);
    }
}
