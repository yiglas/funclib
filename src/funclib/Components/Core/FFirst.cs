using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the funclib.Core.First( item's funclib.Core.First( item. Same as <see cref="First.Invoke(First.Invoke(object))"/>.
    /// </summary>
    public class FFirst :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the funclib.Core.First( item's funclib.Core.First( item. Same as <see cref="First.Invoke(First.Invoke(object))"/>.
        /// </summary>
        /// <param name="x">Object to return the funclib.Core.First( item's funclib.Core.First( item.</param>
        /// <returns>
        /// Returns the funclib.Core.First( item's funclib.Core.First( item
        /// </returns>
        public object Invoke(object x) => funclib.Core.First(funclib.Core.First(x));
    }
}
