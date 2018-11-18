using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is a <see cref="IMap"/>, otherwise false.
    /// </summary>
    public class IsMap :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a <see cref="IMap"/>, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is a <see cref="IMap"/>, otherwise false.
        /// </returns>
        public object Invoke(object x) => x is IMap;
    }
}
