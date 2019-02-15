using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the first item's first item. Same as First(First(x)).
    /// </summary>
    public class FFirst :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the first item's first item. Same as First(First(x)).
        /// </summary>
        /// <param name="x">Object to return the first item's first item.</param>
        /// <returns>
        /// Returns the first item's first item
        /// </returns>
        public object Invoke(object x) => funclib.Core.First(funclib.Core.First(x));
    }
}
