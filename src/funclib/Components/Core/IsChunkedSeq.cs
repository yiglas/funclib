using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if s is a <see cref="IChunkedSeq"/>, otherwise <see cref="false"/>.
    /// </summary>
    public class IsChunkedSeq :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if s is a <see cref="IChunkedSeq"/>, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="s">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if s is a <see cref="IChunkedSeq"/>, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object s) => new IsInstance().Invoke(typeof(IChunkedSeq), s);
    }
}
