using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is zero, otherwise <see cref="false"/>.
    /// </summary>
    public class IsZero :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is zero, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is zero, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object n) => Numbers.IsZero(n);
    }
}
