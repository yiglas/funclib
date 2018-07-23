using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the sum of numbers. No parameters past returns 0.
    /// </summary>
    public class Plus :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns the sum of numbers. No parameters past returns 0.
        /// </summary>
        /// <returns>
        /// Returns 0.
        /// </returns>
        public object Invoke() => 0;
        /// <summary>
        /// Returns the sum of numbers. No parameters past returns 0.
        /// </summary>
        /// <param name="x">First parameter added.</param>
        /// <returns>
        /// Returns the sum of numbers. No parameters past returns 0.
        /// </returns>
        public object Invoke(object x) => Invoke(x, 0);
        /// <summary>
        /// Returns the sum of numbers. No parameters past returns 0.
        /// </summary>
        /// <param name="x">First parameter added.</param>
        /// <param name="y">Second parameter added.</param>
        /// <returns>
        /// Returns the sum of numbers. No parameters past returns 0.
        /// </returns>
        public object Invoke(object x, object y) => Numbers.Add(x, y);
        /// <summary>
        /// Returns the sum of numbers. No parameters past returns 0.
        /// </summary>
        /// <param name="x">First parameter added.</param>
        /// <param name="y">Second parameter added.</param>
        /// <param name="more">Rest of the parameters to add.</param>
        /// <returns>
        /// Returns the sum of numbers. No parameters past returns 0.
        /// </returns>
        public object Invoke(object x, object y, params object[] more) => reduce1(this, Invoke(x, y), more);
    }
}
