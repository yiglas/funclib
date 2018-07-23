using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Seq"/> of the items in coll in reverse order.
    /// </summary>
    public class Reverse :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="Seq"/> of the items in coll in reverse order.
        /// </summary>
        /// <param name="coll">A collection to return.</param>
        /// <returns>
        /// Returns a <see cref="Seq"/> of the items in coll in reverse order.
        /// </returns>
        public object Invoke(object coll) => reduce1(new Conj(), list(), coll);
    }
}
