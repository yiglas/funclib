using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is not <see cref="null"/>, otherwise <see cref="false"/>.
    /// </summary>
    public class IsSome :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is not <see cref="null"/>, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is not <see cref="null"/>, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x) => not(isNull(x));
    }
}
