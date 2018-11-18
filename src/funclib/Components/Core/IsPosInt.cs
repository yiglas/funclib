using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is a positive <see cref="IsInt"/>, otherwise false.
    /// </summary>
    public class IsPosInt :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a positive <see cref="IsInt"/>, otherwise false.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns true if x is a positive <see cref="IsInt"/>, otherwise false.
        /// </returns>
        public object Invoke(object n) => funclib.Core.And(funclib.Core.IsInt(n), funclib.Core.IsPos(n));
    }
}
