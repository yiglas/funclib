using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is logical false, otherwise false.
    /// </summary>
    public class Not :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is logical false, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is logical false, otherwise false.
        /// </returns>
        public object Invoke(object x) => !(bool)funclib.Core.Truthy(x);
    }
}
