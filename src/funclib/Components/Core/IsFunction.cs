using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is a <see cref="IFunction"/>, otherwise false.
    /// </summary>
    public class IsFunction :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a <see cref="IFunction"/>, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is a <see cref="IFunction"/>, otherwise false.
        /// </returns>
        public object Invoke(object x) => x is IFunction;
    }
}
