using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if coll has no items. Same as <see cref="Not.Invoke(Seq.Invoke(object))"/>.
    /// </summary>
    public class IsEmpty :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if coll has no items. Same as <see cref="Not.Invoke(Seq.Invoke(object))"/>.
        /// </summary>
        /// <param name="coll">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if coll has no items. Same as <see cref="Not.Invoke(Seq.Invoke(object))"/>.
        /// </returns>
        public object Invoke(object coll) => not(seq(coll));
    }
}
