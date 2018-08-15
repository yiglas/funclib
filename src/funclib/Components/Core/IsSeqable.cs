using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x can be supported by the <see cref="Seq"/> function, otherwise <see cref="false"/>.
    /// </summary>
    public class IsSeqable :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x can be supported by the <see cref="Seq"/> function, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x can be supported by the <see cref="Seq"/> function, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x) =>
            x is null
                || x is ISeq
                || x is ISeqable
                || x.GetType().IsArray
                || x is string
                || x is System.Collections.IEnumerable;
    }
}
