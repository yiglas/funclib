using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if n is an even number.
    /// </summary>
    public class IsEven :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if n is an even number.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns true if n is an even number.
        /// </returns>
        public object Invoke(object n) => funclib.Core.IsZero(funclib.Core.BitAnd(Numbers.ConvertToLong(n), 1));
    }
}
