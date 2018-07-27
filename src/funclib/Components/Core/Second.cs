using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Same as <see cref="First.Invoke(Next.Invoke(object))"/>.
    /// </summary>
    public class Second :
        IFunction<object, object>
    {
        /// <summary>
        /// Same as <see cref="First.Invoke(Next.Invoke(object))"/>.
        /// </summary>
        /// <param name="x">Should be a <see cref="Collections.ISeqable"/> collection.</param>
        /// <returns>
        /// Returns the 2nd item in the collection.
        /// </returns>
        public object Invoke(object x) => first(next(x));
    }
}
