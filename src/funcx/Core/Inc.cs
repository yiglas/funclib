using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns a number one greater than x.
    /// </summary>
    public class Inc :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a number one greater than x.
        /// </summary>
        /// <param name="x">Number to incremental by one.</param>
        /// <returns>
        /// Returns a number one greater than x.
        /// </returns>
        public object Invoke(object x) => Numbers.Inc(x);
    }
}
