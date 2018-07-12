using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
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
