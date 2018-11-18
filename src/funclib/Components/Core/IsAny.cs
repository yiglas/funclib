using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true given any argument.
    /// </summary>
    public class IsAny :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true given any argument.
        /// </summary>
        /// <param name="x">Given argument.</param>
        /// <returns>
        /// Returns true given any argument.
        /// </returns>
        public object Invoke(object x) => true;
    }
}
