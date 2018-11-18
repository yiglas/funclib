using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is a <see cref="double"/>, otherwise false.
    /// </summary>
    public class IsDouble :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a <see cref="double"/>, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is a <see cref="double"/>, otherwise false.
        /// </returns>
        public object Invoke(object x) => x is double;
    }
}
