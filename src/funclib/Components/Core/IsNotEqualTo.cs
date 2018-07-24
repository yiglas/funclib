using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
    /// </summary>
    public class IsNotEqualTo :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <returns>
        /// Returns false.
        /// </returns>
        public object Invoke(object x) => false;
        /// <summary>
        /// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test</param>
        /// <returns>
        /// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
        /// </returns>
        public object Invoke(object x, object y) => not(isEqualTo(x, y));
        /// <summary>
        /// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test against.</param>
        /// <param name="more">All other elements to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
        /// </returns>
        public object Invoke(object x, object y, params object[] more) => not(apply(funclib.Core.IsEqualTo, x, y, more));
    }
}
