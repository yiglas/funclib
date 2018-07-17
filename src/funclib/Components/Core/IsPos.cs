using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is an greater than zero, otherwise <see cref="false"/>.
    /// </summary>
    public class IsPos :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is an greater than zero, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="num">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is an greater than zero, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object num) => Numbers.IsPos(num);
    }
}
