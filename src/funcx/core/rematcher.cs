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
        /// Returns an instance of the <see cref="ReMatcher"/> class.
        /// </summary>
        /// <param name="re">The Regex pattern.</param>
        /// <param name="s">The string to pattern match.</param>
        /// <returns>
        /// Returns an instanc eof the <see cref="ReMatcher"/> class.
        /// </returns>
        public static ReMatcher rematcher(Regex re, string s) => new ReMatcher(re, s);
    }
}
