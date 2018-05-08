namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static partial class core
    {
        /// <summary>
        /// Returns the match, if any, of string to pattern, using matches. Uses regroups to return the groups.
        /// </summary>
        /// <param name="re">the <see cref="Regex"/> object.</param>
        /// <param name="s">The string to match with.</param>
        /// <returns>
        /// Returns a List found matches.
        /// </returns>
        public static IList<string> rematches(Regex re, string s) =>
            let(rematcher(re, s),
                m => m.Matches() ? regroups(m) : null);
    }
}
