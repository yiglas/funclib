using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is of type <see cref="Volatileǃ"/>, otherwise false.
    /// </summary>
    public class IsVolatile :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is of type <see cref="Volatileǃ"/>, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is of type <see cref="Volatileǃ"/>, otherwise false.
        /// </returns>
        public object Invoke(object x) => x is Volatileǃ;
    }
}
