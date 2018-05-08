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
        /// Returns a new instance of the <see cref="Regex"/> class.
        /// </summary>
        /// <param name="s">The pattern.</param>
        /// <returns>
        /// A new <see cref="Regex"/> class.
        /// </returns>
        public static Regex repattern(string s) => new Regex(s);
    }
}
