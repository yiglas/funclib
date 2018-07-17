using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if n is an even number.
    /// </summary>
    public class IsEven :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if n is an even number.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if n is an even number.
        /// </returns>
        public object Invoke(object n) => new IsZero().Invoke(new BitAnd().Invoke(Numbers.ConvertToLong(n), 1));
    }
}
