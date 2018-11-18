using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is of type <see cref="Reduced"/>, otherwise false.
    /// </summary>
    public class IsReduced :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is of type <see cref="Reduced"/>, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is of type <see cref="Reduced"/>, otherwise false.
        /// </returns>
        public object Invoke(object x) => x is Reduced;
    }
}
