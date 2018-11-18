using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is a non-negative <see cref="int"/>, otherwise false.
    /// </summary>
    public class IsNatInt :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a non-negative <see cref="int"/>, otherwise false.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns true if x is a non-negative <see cref="int"/>, otherwise false.
        /// </returns>
        public object Invoke(object n) => funclib.Core.And(funclib.Core.IsInt(n), funclib.Core.Not(funclib.Core.IsNeg(n)));
    }
}
