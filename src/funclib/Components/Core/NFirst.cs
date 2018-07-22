using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Same as <see cref="Next.Invoke(First.Invoke(object))"/>.
    /// </summary>
    public class NFirst :
        IFunction<object, object>
    {
        /// <summary>
        /// Same as <see cref="Next.Invoke(First.Invoke(object))"/>.
        /// </summary>
        /// <param name="x">Object to return the first item's next item.</param>
        /// <returns>
        /// Returns the first item's next item
        /// </returns>
        public object Invoke(object x) => new Next().Invoke(first(x));
    }
}
