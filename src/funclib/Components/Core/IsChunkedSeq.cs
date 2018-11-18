using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if s is a <see cref="IChunkedSeq"/>, otherwise false.
    /// </summary>
    public class IsChunkedSeq :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if s is a <see cref="IChunkedSeq"/>, otherwise false.
        /// </summary>
        /// <param name="s">Object to test.</param>
        /// <returns>
        /// Returns true if s is a <see cref="IChunkedSeq"/>, otherwise false.
        /// </returns>
        public object Invoke(object s) => s is IChunkedSeq;
    }
}
