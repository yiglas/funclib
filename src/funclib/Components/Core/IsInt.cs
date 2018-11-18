using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is a <see cref="int"/>, <see cref="long"/>, <see cref="short"/> or <see cref="byte"/>, otherwise false.
    /// </summary>
    public class IsInt :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a <see cref="int"/>, <see cref="long"/>, <see cref="short"/> or <see cref="byte"/>, otherwise false.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns true if x is a <see cref="int"/>, <see cref="long"/>, <see cref="short"/> or <see cref="byte"/>, otherwise false.
        /// </returns>
        public object Invoke(object n) => funclib.Core.Or(n is int, n is long, n is short, n is byte);
    }
}
