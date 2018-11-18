using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is an odd number, otherwise false.
    /// </summary>
    public class IsOdd :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is an odd number, otherwise false.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns true if x is an odd number, otherwise false.
        /// </returns>
        public object Invoke(object n) => funclib.Core.Not(funclib.Core.IsEven(n));
    }
}
