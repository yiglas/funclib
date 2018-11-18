using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is a <see cref="IList"/>, otherwise false.
    /// </summary>
    public class IsList :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a <see cref="IList"/>, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is a <see cref="IList"/>, otherwise false.
        /// </returns>
        public object Invoke(object x) => x is IList;
    }
}
