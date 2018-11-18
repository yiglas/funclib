using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is an greater than zero, otherwise false.
    /// </summary>
    public class IsPos :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is an greater than zero, otherwise false.
        /// </summary>
        /// <param name="num">Object to test.</param>
        /// <returns>
        /// Returns true if x is an greater than zero, otherwise false.
        /// </returns>
        public object Invoke(object num) => Numbers.IsPos(num);
    }
}
