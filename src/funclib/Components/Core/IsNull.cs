using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is <see cref="null"/>, otherwise false.
    /// </summary>
    public class IsNull :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is <see cref="null"/>, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is <see cref="null"/>, otherwise false.
        /// </returns>
        public object Invoke(object x) => x is null;
    }
}
