using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the least of the numbers.
    /// </summary>
    public class Min :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns the least of the numbers.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns x.
        /// </returns>
        public object Invoke(object x) => x;
        /// <summary>
        /// Returns the least of the numbers.
        /// </summary>
        /// <param name="x">First object to test.</param>
        /// <param name="y">Second object to test.</param>
        /// <returns>
        /// Returns the greatest of the numbers.
        /// </returns>
        public object Invoke(object x, object y) => Numbers.Min(x, y);
        /// <summary>
        /// Returns the least of the numbers.
        /// </summary>
        /// <param name="x">First object to test.</param>
        /// <param name="y">Second object to test.</param>
        /// <param name="more">Rest of the objects to test.</param>
        /// <returns>
        /// Returns the greatest of the numbers.
        /// </returns>
        public object Invoke(object x, object y, params object[] more) =>
            new Reduce1().Invoke(this, Invoke(x, y), more);
    }
}
