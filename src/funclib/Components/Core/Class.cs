using funclib.Components.Core.Generic;
using System;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the type of an object.
    /// </summary>
    public class Class :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the type of an object.
        /// </summary>
        /// <param name="x">Object to get the type of.</param>
        /// <returns>
        /// Returns the <see cref="Type"/> of object x.
        /// </returns>
        public object Invoke(object x) => x?.GetType();
    }
}
