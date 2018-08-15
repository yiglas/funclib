using funclib.Collections.Internal;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Removes the last time from a <see cref="ITransientVector"/>. If
    /// the collection is empty, throw an exception.
    /// </summary>
    public class Popǃ :
        IFunction<object, object>
    {
        /// <summary>
        /// Removes the last time from a <see cref="ITransientVector"/>. If
        /// the collection is empty, throw an exception.
        /// </summary>
        /// <param name="coll">An object that implements the <see cref="ITransientVector"/> interface.</param>
        /// <returns>
        /// Returns coll.
        /// </returns>
        public object Invoke(object coll) => ((ITransientVector)coll).Pop();
    }
}
