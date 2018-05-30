namespace FunctionalLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns a possibly empty sequence of items after the first.
        /// </summary>
        /// <typeparam name="T">Generic type of the collection.</typeparam>
        /// <param name="coll">The <see cref="IEnumerable{T}"/>.</param>
        /// <returns></returns>
        public static IEnumerable<T> rest<T>(IEnumerable<T> coll)
        {
            if (coll == null) yield break;

            int i = 0;
            foreach (var item in coll)
                if (i++ == 0) continue; else yield return item;
        }

        /// <summary>
        /// Returns a possibly empty sequence of items after the first.
        /// </summary>
        /// <param name="coll">The <see cref="IEnumerable"/>.</param>
        /// <returns></returns>
        public static IEnumerable rest(IEnumerable coll)
        {
            if (coll == null) yield break;

            int i = 0;
            foreach (var item in coll)
                if (i++ == 0) continue; else yield return item;
        }
    }
}
