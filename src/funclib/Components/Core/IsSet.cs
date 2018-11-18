using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if coll implements <see cref="ISet"/> interface, otherwise false.
    /// </summary>
    public class IsSet :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if coll implements <see cref="ISequential"/> interface, otherwise false.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns true if coll implements <see cref="ISequential"/> interface, otherwise false.
        /// </returns>
        public object Invoke(object x) => x is ISet;
    }
}
