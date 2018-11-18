using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if coll implements <see cref="ISequential"/> interface, otherwise false.
    /// </summary>
    public class IsSequential :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if coll implements <see cref="ISequential"/> interface, otherwise false.
        /// </summary>
        /// <param name="coll">An object to test against.</param>
        /// <returns>
        /// Returns true if coll implements <see cref="ISequential"/> interface, otherwise false.
        /// </returns>
        public object Invoke(object coll) => coll is ISequential;
    }
}
