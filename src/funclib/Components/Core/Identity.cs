using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns its argument.
    /// </summary>
    public class Identity :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns its argument.
        /// </summary>
        /// <param name="x">Argument to return.</param>
        /// <returns>
        /// Returns its argument.
        /// </returns>
        public object Invoke(object x) => x;
    }
}
