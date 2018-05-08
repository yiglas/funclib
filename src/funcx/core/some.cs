namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns the first logical true value of the predicate for any x in coll. else null.
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="pred">The predicate to test for.</param>
        /// <param name="coll">The collection to test against.</param>
        /// <returns>
        /// The first logical true value of the predicate for any x in coll, otherwise null
        /// </returns>
        public static bool? some<T>(Func<T, bool> pred, IEnumerable<T> coll) => coll.Where(pred).Any();
    }
}
