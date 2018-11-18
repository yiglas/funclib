using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is a <see cref="string"/>, otherwise false.
    /// </summary>
    public class IsString :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a <see cref="string"/>, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is a <see cref="string"/>, otherwise false.
        /// </returns>
        public object Invoke(object x) => x is string;
    }
}
