using funclib.Components.Core.Generic;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the current state of <see cref="IDeref"/> variable.
    /// </summary>
    public class Deref :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the current state of <see cref="IDeref"/> variable.
        /// </summary>
        /// <param name="ref">Object that implements the <see cref="IDeref"/> interface.</param>
        /// <returns>
        /// Returns the current state of <see cref="IDeref"/> variable.
        /// </returns>
        public object Invoke(object @ref) => ((IDeref)@ref).Deref();
    }
}
