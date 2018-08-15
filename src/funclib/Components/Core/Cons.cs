using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a new <see cref="ISeq"/> where x is the funclib.Core.First( element and seq is the rest.
    /// </summary>
    public class Cons :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a new <see cref="ISeq"/> where x is the funclib.Core.First( element and seq is the rest.
        /// </summary>
        /// <param name="x">Object to be the funclib.Core.First( in the <see cref="ISeq"/> object.</param>
        /// <param name="seq">Object to be the rest of the <see cref="ISeq"/> object.</param>
        /// <returns>
        /// Returns a <see cref="ISeq"/> collection.
        /// </returns>
        public object Invoke(object x, object seq)
        {
            if (seq is null) return funclib.Core.List(x);
            if (seq is ISeq e) return new Collections.Cons(x, e);
            return new Collections.Cons(x, (ISeq)funclib.Core.Seq(seq));
        }
    }
}
