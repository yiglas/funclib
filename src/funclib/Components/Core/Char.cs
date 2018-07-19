using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Coerce to char
    /// </summary>
    public class Char :
        IFunction<object, object>
    {
        /// <summary>
        /// Coerce to char
        /// </summary>
        /// <param name="x">The number to convert to a <see cref="char"/>.</param>
        /// <returns>
        /// Returns a <see cref="char"/> value.
        /// </returns>
        public object Invoke(object x)
        {
            if (x is char) return x;

            var n = Numbers.ConvertToLong(x);
            if (n < char.MinValue || n > char.MaxValue)
                throw new ArgumentException($"Value is out of range for char: {x}");

            return (char)n;
        }
    }
}
