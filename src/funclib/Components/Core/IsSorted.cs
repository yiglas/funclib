using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if coll implements <see cref="ISorted"/> interface, otherwise <see cref="false"/>.
    /// </summary>
    public class IsSorted :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if coll implements <see cref="ISorted"/> interface, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="coll">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if coll implements <see cref="ISorted"/> interface, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object coll) => isInstance(typeof(ISorted), coll);
    }
}
