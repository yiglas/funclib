namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns true if the object has no items - same as not(seq(coll)).
        /// Please use the idiom seq(obj) rather than (not(isempty(obj)).
        /// </summary>
        /// <param name="coll">The <see cref="object"/>.</param>
        /// <returns>
        /// true if the object is empty, otherwise false.
        /// </returns>
        public static bool isempty(object coll) => not(seq(coll));
    }
}
