using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is <see cref="true"/>, otherwise <see cref="false"/>.
    /// </summary>
    public class IsTrue :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is <see cref="true"/>, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is <see cref="true"/>, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x) => x is true;
    }
}
