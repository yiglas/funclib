using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is zero, otherwise false.
    /// </summary>
    public class IsZero :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is zero, otherwise false.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns true if x is zero, otherwise false.
        /// </returns>
        public object Invoke(object n) => Numbers.IsZero(n);
    }
}
