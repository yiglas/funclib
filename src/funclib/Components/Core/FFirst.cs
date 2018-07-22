using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the first item's first item. Same as <see cref="First.Invoke(First.Invoke(object))"/>.
    /// </summary>
    public class FFirst :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the first item's first item. Same as <see cref="First.Invoke(First.Invoke(object))"/>.
        /// </summary>
        /// <param name="x">Object to return the first item's first item.</param>
        /// <returns>
        /// Returns the first item's first item
        /// </returns>
        public object Invoke(object x) => first(first(x));
    }
}
