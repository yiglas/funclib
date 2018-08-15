using funclib.Components.Core.Generic;

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
        public object Invoke(object coll) => funclib.Core.Reduce1(funclib.Core.conj, funclib.Core.List(), coll);
    }
}
