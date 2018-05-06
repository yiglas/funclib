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
        /// For a <see cref="IEnumerable{T}"/>, same as first, if the collection is empty, returns nil.
        /// </summary>
        /// <typeparam name="T">Type of the list.</typeparam>
        /// <param name="coll">collection to peek into.</param>
        /// <returns>
        /// Returns the first item in the list.
        /// </returns>
        public static T peek<T>(IEnumerable<T> coll) => 
            coll == null 
                ? default
                : coll.FirstOrDefault();

    }
}
