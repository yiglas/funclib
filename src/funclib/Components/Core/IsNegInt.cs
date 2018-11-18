using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is a a negative <see cref="int"/>, otherwise false.
    /// </summary>
    public class IsNegInt :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a a negative <see cref="int"/>, otherwise false.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns true if x is a a negative <see cref="int"/>, otherwise false.
        /// </returns>
        public object Invoke(object n) => funclib.Core.And(funclib.Core.IsInt(n), funclib.Core.IsNeg(n));
    }
}
