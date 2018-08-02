using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if coll implements <see cref="IVector"/> interface, otherwise <see cref="false"/>.
    /// </summary>
    public class IsVector :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if coll implements <see cref="IVector"/> interface, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if coll implements <see cref="IVector"/> interface, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x) => x is IVector;
    }
}
