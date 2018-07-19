using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a (infinite!, or length n is supplied) <see cref="LazySeq"/> of xs.
    /// </summary>
    public class Repeat :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a (infinite!, or length n is supplied) <see cref="LazySeq"/> of xs.
        /// </summary>
        /// <param name="x">Object to repeat.</param>
        /// <returns>
        /// Returns a (infinite!, or length n is supplied) <see cref="LazySeq"/> of xs.
        /// </returns>
        public object Invoke(object x) => Collections.Repeat.Create(x);
        /// <summary>
        /// Returns a (infinite!, or length n is supplied) <see cref="LazySeq"/> of xs.
        /// </summary>
        /// <param name="n">A <see cref="long"/> that specifies the number of objects.</param>
        /// <param name="x">Object to repeat.</param>
        /// <returns>
        /// Returns a (infinite!, or length n is supplied) <see cref="LazySeq"/> of xs.
        /// </returns>
        public object Invoke(object n, object x) => Collections.Repeat.Create(Numbers.ConvertToLong(n), x);
    }
}
