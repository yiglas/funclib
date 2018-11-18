using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if values are not equal, otherwise false
    /// </summary>
    public class IsNotEqualTo :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns true if values are not equal, otherwise false
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <returns>
        /// Returns false.
        /// </returns>
        public object Invoke(object x) => false;
        /// <summary>
        /// Returns true if values are not equal, otherwise false
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test</param>
        /// <returns>
        /// Returns true if values are not equal, otherwise false
        /// </returns>
        public object Invoke(object x, object y) => funclib.Core.Not(funclib.Core.IsEqualTo(x, y));
        /// <summary>
        /// Returns true if values are not equal, otherwise false
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test against.</param>
        /// <param name="more">All other elements to test.</param>
        /// <returns>
        /// Returns true if values are not equal, otherwise false
        /// </returns>
        public object Invoke(object x, object y, params object[] more) => funclib.Core.Not(funclib.Core.Apply(funclib.Core.isEqualTo, x, y, more));
    }
}
