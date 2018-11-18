using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is a <see cref="ICounted"/>, otherwise false.
    /// </summary>
    public class IsCounted :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a <see cref="ICounted"/>, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is a <see cref="ICounted"/>, otherwise false.
        /// </returns>
        public object Invoke(object x) => x is ICounted;
    }
}
