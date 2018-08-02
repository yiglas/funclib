using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is a positive <see cref="IsInt"/>, otherwise <see cref="false"/>.
    /// </summary>
    public class IsPosInt :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is a positive <see cref="IsInt"/>, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is a positive <see cref="IsInt"/>, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object n) => and(isInt(n), isPos(n));
    }
}
