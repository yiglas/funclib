using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the current state of ref.
    /// </summary>
    public class Deref :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the current state of ref.
        /// </summary>
        /// <param name="ref">Object that implements the <see cref="IDeref"/> interface.</param>
        /// <returns>
        /// Returns the current state of ref.
        /// </returns>
        public object Invoke(object @ref) => ((IDeref)@ref).Deref();
    }
}
