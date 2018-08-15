using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a new transient version of the collection, in constant time.
    /// </summary>
    public class Transient :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a new transient version of the collection, in constant time.
        /// </summary>
        /// <param name="coll">An object that implements the <see cref="IEditableCollection"/> interface.</param>
        /// <returns>
        /// Returns a new transient version of the collection, in constant time.
        /// </returns>
        public object Invoke(object coll) => ((IEditableCollection)coll).ToTransient();
    }
}
