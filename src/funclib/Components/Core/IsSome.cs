using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is not null, otherwise false.
    /// </summary>
    public class IsSome :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is not null, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is not null, otherwise false.
        /// </returns>
        public object Invoke(object x) => funclib.Core.Not(funclib.Core.IsNull(x));
    }
}
