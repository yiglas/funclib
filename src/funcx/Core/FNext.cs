using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
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
        public object Invoke(object x) => new First().Invoke(new Next().Invoke(x));
    }
}
