using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is a non-negative <see cref="int"/>, otherwise <see cref="false"/>.
    /// </summary>
    public class IsNatInt :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is a non-negative <see cref="int"/>, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is a non-negative <see cref="int"/>, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object n) =>
            and(
                new IsInt().Invoke(n),
                new Not().Invoke(new IsNeg().Invoke(n)));
    }
}
