using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// If y is not suppled return <see cref="Numbers.Negate(object)"/> of x, else subtract 
    /// ys from x and returns the result.
    /// </summary>
    public class Minus :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// If y is not suppled return <see cref="Numbers.Negate(object)"/> of x, else subtract 
        /// ys from x and returns the result.
        /// </summary>
        /// <param name="x">Object to <see cref="Numbers.Negate(object)"/>.</param>
        /// <returns>
        /// Returns <see cref="Numbers.Negate(object)"/> of x.
        /// </returns>
        public object Invoke(object x) => Numbers.Negate(x);
        /// <summary>
        /// If y is not suppled return <see cref="Numbers.Negate(object)"/> of x, else subtract 
        /// ys from x and returns the result.
        /// </summary>
        /// <param name="x">First number to subtract.</param>
        /// <param name="y">Second number to subtract.</param>
        /// <returns>
        /// Returns the result from subtracting y from x.
        /// </returns>
        public object Invoke(object x, object y) => Numbers.Subtract(x, y);
        /// <summary>
        /// If y is not suppled return <see cref="Numbers.Negate(object)"/> of x, else subtract 
        /// ys from x and returns the result.
        /// </summary>
        /// <param name="x">First number to subtract.</param>
        /// <param name="y">Second number to subtract.</param>
        /// <param name="more">Rest of the numbers to subtract.</param>
        /// <returns>
        /// Returns the result of subtracting y from x then rest of the more values.
        /// </returns>
        public object Invoke(object x, object y, params object[] more) => reduce1(this, Invoke(x, y), more);
    }
}
