using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the product of numbers. No parameters past returns 1. Single parameter there is an 
    /// implicit 1 passed.
    /// </summary>
    public class Multiply :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns the product of numbers. No parameters past returns 1. Single parameter there is an 
        /// implicit 1 passed.
        /// </summary>
        /// <returns>
        /// Returns 1.
        /// </returns>
        public object Invoke() => 1;
        /// <summary>
        /// Returns the product of numbers. No parameters past returns 1. Single parameter there is an 
        /// implicit 1 passed.
        /// </summary>
        /// <param name="x">First parameter multiply.</param>
        /// <returns>
        /// Returns the product of numbers. No parameters past returns 1. Single parameter there is an 
        /// implicit 1 passed.
        /// </returns>
        public object Invoke(object x) => Invoke(x, 1);
        /// <summary>
        /// Returns the product of numbers. No parameters past returns 1. Single parameter there is an 
        /// implicit 1 passed.
        /// </summary>
        /// <param name="x">First parameter multiply.</param>
        /// <param name="y">Second parameter multiply.</param>
        /// <returns>
        /// Returns the product of numbers. No parameters past returns 1. Single parameter there is an 
        /// implicit 1 passed.
        /// </returns>
        public object Invoke(object x, object y) => Numbers.Multiply(x, y);
        /// <summary>
        /// Returns the product of numbers. No parameters past returns 1. Single parameter there is an 
        /// implicit 1 passed.
        /// </summary>
        /// <param name="x">First parameter multiply.</param>
        /// <param name="y">Second parameter multiply.</param>
        /// <param name="more">Rest of the parameters to multiply.</param>
        /// <returns>
        /// Returns the product of numbers. No parameters past returns 1. Single parameter there is an 
        /// implicit 1 passed.
        /// </returns>
        public object Invoke(object x, object y, params object[] more) => funclib.Core.Reduce1(this, Invoke(x, y), more);
    }
}
