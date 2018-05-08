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
        /// Returns a lazy sequence of successive matches of patterns in the string.
        /// </summary>
        /// <param name="re">the <see cref="Regex"/> object.</param>
        /// <param name="s">The string to pattern match against.</param>
        /// <returns>
        /// Returns a lazy sequence of successive matches.
        /// </returns>
        public static IEnumerable<IList<string>> reseq(Regex re, string s)
        {
            var m = rematcher(re, s);

            while (m.Find())
                yield return regroups(m);
        }
    }
}
