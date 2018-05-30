namespace FunctionalLibrary
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
        /// Returns the nth rest of coll, coll when n is 0
        /// </summary>
        /// <typeparam name="TResult">The type of objects to enumerate.</typeparam>
        /// <param name="coll">The <see cref="IEnumerable{T}"/> we are pulling the values from.</param>
        /// <param name="n">Where to start returning the values from</param>
        /// <returns>
        /// Returns a list of items from coll starting at n.
        /// </returns>
        public static IEnumerable<TResult> nthrest<TResult>(IEnumerable<TResult> coll, int n)
        {
            if (coll == null) return null;
            if (n == 0) return coll;

            var list = new List<TResult>(drop(n, coll));

            return list;
        }
    }
}
