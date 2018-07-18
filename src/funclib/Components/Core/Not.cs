using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is logical false, otherwise <see cref="false"/>.
    /// </summary>
    public class Not :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is logical false, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is logical false, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x) => !(bool)new Truthy().Invoke(x);
    }
}
