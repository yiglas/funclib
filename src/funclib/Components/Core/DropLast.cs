using funclib.Components.Core.Generic;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of all but the last n items. Default is 1.
    /// </summary>
    public class DropLast :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of all but the last n items. Default is 1.
        /// </summary>
        /// <param name="coll">Collection of items to remove the last one from.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> with all but the last item.
        /// </returns>
        public object Invoke(object coll) => Invoke(1, coll);
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of all but the last n items. Default is 1.
        /// </summary>
        /// <param name="n">An <see cref="int"/> of the last times from the collection.</param>
        /// <param name="coll">The collection to remove from.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of items without the last n items.
        /// </returns>
        public object Invoke(object n, object coll) => map(func((object x, object _) => x), coll, drop(n, coll));
    }
}
