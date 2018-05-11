namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static partial class core
    {
        /// <summary>
        /// Returns a random integer between 0 (inclusive) and n (exclusive).
        /// </summary>
        /// <param name="n">Upper bounds of the random number</param>
        /// <returns>
        /// Returns a random number.
        /// </returns>
        public static int randint(int n) => (int)rand(n);
    }
}
