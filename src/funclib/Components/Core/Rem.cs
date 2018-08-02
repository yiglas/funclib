using funclib.Components.Core.Generic;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the remainder of dividing the numerator by the denominator.
    /// </summary>
    public class Rem :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns the remainder of dividing the numerator by the denominator.
        /// </summary>
        /// <param name="num">The numerator.</param>
        /// <param name="div">the denominator.</param>
        /// <returns>
        /// Returns the remainder of dividing the numerator by the denominator.
        /// </returns>
        public object Invoke(object num, object div) => Numbers.Remainder(num, div);
    }
}
