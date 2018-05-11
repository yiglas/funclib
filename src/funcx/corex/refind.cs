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
        /// Returns the next regex match, if any, of string to pattern, using find. Uses regroups to return the groups.
        /// </summary>
        /// <param name="m">A <see cref="ReMatcher"/> object.</param>
        /// <returns>
        /// Returns the next regex match.
        /// </returns>
        public static IList<string> refind(ReMatcher m) => m?.Find() ?? false ? regroups(m) : null;

        /// <summary>
        /// Returns the next regex match, if any, of string to pattern, using find. Uses regroups to return the groups.
        /// </summary>
        /// <param name="re">Regex pattern</param>
        /// <param name="s">The string to pattern match to</param>
        /// <returns>
        /// Returns the next regex match.
        /// </returns>
        public static IList<string> refind(Regex re, string s) => refind(rematcher(re, s));
    }
}
