using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is false, otherwise false.
    /// </summary>
    public class IsFalse :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a false, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is a false, otherwise false.
        /// </returns>
        public object Invoke(object x) => x is false;
    }
}
