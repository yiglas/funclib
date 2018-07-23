using System;
using System.Text;
using System.Text.RegularExpressions;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the next <see cref="Regex"/> match, if any, of string to pattern, using <see cref="funclib.ReMatcher.Find"/>.
    /// Uses <see cref="ReGroups"/> to return the group.
    /// </summary>
    public class ReFind :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns the next <see cref="Regex"/> match, if any, of string to pattern, using <see cref="ReMatcher.Find"/>.
        /// Uses <see cref="ReGroups"/> to return the group.
        /// </summary>
        /// <param name="m">A <see cref="ReMatcher"/> object already initialized.</param>
        /// <returns>
        /// Returns the next <see cref="Regex"/> match, if any, of string to pattern, using <see cref="ReMatcher.Find"/>.
        /// Uses <see cref="ReGroups"/> to return the group.
        /// </returns>
        public object Invoke(object m) => ((ReMatcher)m).Find() ? reGroups(m) : null;
        /// <summary>
        /// Returns the next <see cref="Regex"/> match, if any, of string to pattern, using <see cref="ReMatcher.Find"/>.
        /// Uses <see cref="ReGroups"/> to return the group.
        /// </summary>
        /// <param name="re">An object that is already a <see cref="Regex"/> instance.</param>
        /// <param name="s">The string to search for a match(s).</param>
        /// <returns>
        /// Returns the next <see cref="Regex"/> match, if any, of string to pattern, using <see cref="ReMatcher.Find"/>.
        /// Uses <see cref="ReGroups"/> to return the group.
        /// </returns>
        public object Invoke(object re, object s) => Invoke(new ReMatcher().Invoke(re, s));
    }
}
