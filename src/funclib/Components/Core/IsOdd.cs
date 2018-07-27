using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is an odd number, otherwise <see cref="false"/>.
    /// </summary>
    public class IsOdd :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is an odd number, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is an odd number, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object n) => not(isEven(n));
    }
}
