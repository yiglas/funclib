using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Same as <see cref="Next.Invoke(Next.Invoke(object))"/>.
    /// </summary>
    public class NNext :
        IFunction<object, object>
    {
        /// <summary>
        /// Same as <see cref="Next.Invoke(Next.Invoke(object))"/>.
        /// </summary>
        /// <param name="x">Object to return the next item's next item.</param>
        /// <returns>
        /// Returns the next item's next item
        /// </returns>
        public object Invoke(object x) => next(next(x));
    }
}
