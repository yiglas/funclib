using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns, in constant time, a <see cref="Seq"/> of the items in
    /// the collection (which can be a <see cref="Collections.Vector"/> or
    /// <see cref="Collections.SortedMap"/>) in reverse order. If collection
    /// is empty returns null.
    /// </summary>
    public class RSeq :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns, in constant time, a <see cref="Seq"/> of the items in
        /// the collection (which can be a <see cref="Collections.Vector"/> or
        /// <see cref="Collections.SortedMap"/>) in reverse order. If collection
        /// is empty returns null.
        /// </summary>
        /// <param name="rev">An object that implements the <see cref="IReversible"/> interface.</param>
        /// <returns>
        /// Returns, in constant time, a <see cref="Seq"/> of the items in
        /// the collection (which can be a <see cref="Collections.Vector"/> or
        /// <see cref="Collections.SortedMap"/>) in reverse order. If collection
        /// is empty returns null.
        /// </returns>
        public object Invoke(object rev) => ((IReversible)rev).RSeq();
    }
}
