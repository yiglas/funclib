using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the first item's next list. Same as First(Next(x)).
    /// </summary>
    public class FNext :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the first item's next list. Same as First(Next(x)).
        /// </summary>
        /// <param name="x">Object to return the first item's next list.</param>
        /// <returns>
        /// Returns the first item's next list.
        /// </returns>
        public object Invoke(object x) => funclib.Core.First(funclib.Core.Next(x));
    }
}
