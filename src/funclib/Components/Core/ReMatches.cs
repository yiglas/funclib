using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the match, if any, of string to pattern, using <see cref="ReMatcher.Matches"/>.
    /// Uses <see cref="ReGroups"/> to return the groups.
    /// </summary>
    public class ReMatches :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns the match, if any, of string to pattern, using <see cref="ReMatcher.Matches"/>.
        /// Uses <see cref="ReGroups"/> to return the groups.
        /// </summary>
        /// <param name="re">An object that is already a <see cref="Regex"/> instance.</param>
        /// <param name="s">The string to search for a match(s).</param>
        /// <returns>
        /// Returns the match, if any, of string to pattern, using <see cref="ReMatcher.Matches"/>.
        /// Uses <see cref="ReGroups"/> to return the groups.
        /// </returns>
        public object Invoke(object re, object s)
        {
            var m = (ReMatcher)reMatcher(re, s);
            if (m.Matches())
                return reGroups(m);

            return null;
        }
    }
}
