using funclib.Components.Core.Generic;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the first item's next list. Same as <see cref="First.Invoke(Next.Invoke(object))"/>.
    /// </summary>
    public class FNext :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the first item's next list. Same as <see cref="First.Invoke(Next.Invoke(object))"/>.
        /// </summary>
        /// <param name="x">Object to return the first item's next list.</param>
        /// <returns>
        /// Returns the first item's next list.
        /// </returns>
        public object Invoke(object x) => first(next(x));
    }
}
