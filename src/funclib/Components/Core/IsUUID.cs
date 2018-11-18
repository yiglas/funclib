using funclib.Components.Core.Generic;
using System;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if x is a <see cref="Guid"/>, otherwise false.
    /// </summary>
    public class IsUUID :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if x is a <see cref="Guid"/>, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if x is a <see cref="Guid"/>, otherwise false.
        /// </returns>
        public object Invoke(object x) => x is Guid;
    }
}
