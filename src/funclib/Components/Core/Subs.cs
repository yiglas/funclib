using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the <see cref="string.Substring(int, int)"/> of s beginning at start inclusive, and ending 
    /// at end (defaults to length of string), exclusive.
    /// </summary>
    public class Subs :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified
        /// character position and continues to the end of the string.
        /// </summary>
        /// <param name="s">String to execute the substring with.</param>
        /// <param name="start">The zero-based starting character position of a substring in this instance.</param>
        /// <returns>
        /// A string that is equivalent to the substring that begins at start in this
        /// instance, or <see cref="string.Empty"/> if start is equal to the length of this
        /// instance.
        /// </returns>
        public object Invoke(object s, object start) => ((string)s).Substring((int)start);
        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified
        /// character position and has a specified length.
        /// </summary>
        /// <param name="s">String to execute the substring with.</param>
        /// <param name="start">The zero-based starting character position of a substring in this instance.</param>
        /// <param name="end">The number of characters in the substring.</param>
        /// <returns>
        /// A string that is equivalent to the substring of length that begins at
        /// start in this instance, or <see cref="string.Empty"/> if start is equal to
        /// the length of this instance and length is zero.
        /// </returns>
        public object Invoke(object s, object start, object end) => ((string)s).Substring((int)start, ((int)end - (int)start));
    }
}
