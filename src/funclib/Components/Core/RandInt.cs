using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Random"/> <see cref="int"/> between 0 (inclusive) and n (exclusive).
    /// </summary>
    public class RandInt :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="Random"/> <see cref="int"/> between 0 (inclusive) and n (exclusive).
        /// </summary>
        /// <param name="n">An <see cref="int"/> for the exclusive value.</param>
        /// <returns>
        /// Returns a <see cref="Random"/> <see cref="int"/> between 0 (inclusive) and n (exclusive).
        /// </returns>
        public object Invoke(object n) => (int)rand(n);
    }
}
