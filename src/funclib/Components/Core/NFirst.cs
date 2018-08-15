using funclib.Components.Core.Generic;

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
        /// <param name="x">Object to return the funclib.Core.First( item's next item.</param>
        /// <returns>
        /// Returns the funclib.Core.First( item's next item
        /// </returns>
        public object Invoke(object x) => funclib.Core.Next(funclib.Core.First(x));
    }
}
