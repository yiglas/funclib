using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if coll implements <see cref="ISorted"/> interface, otherwise false.
    /// </summary>
    public class IsSorted :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if coll implements <see cref="ISorted"/> interface, otherwise false.
        /// </summary>
        /// <param name="coll">Object to test.</param>
        /// <returns>
        /// Returns true if coll implements <see cref="ISorted"/> interface, otherwise false.
        /// </returns>
        public object Invoke(object coll) => coll is ISorted;
    }
}
