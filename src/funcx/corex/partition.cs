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
        // TODO: finish optimizing
        // TODO: add padding ability

        /// <summary>
        /// Returns a lazy sequence of list of n items each, at offsets step apart. If step is not supplied, 
        /// defaults to n, i.e. the partitions do not overlap.
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="n">The number of items to partition the <see cref="IEnumerable{T}"/> into.</param>
        /// <param name="coll">The <see cref="IEnumerable{T}"/> being partitioned.</param>
        /// <returns>
        /// Returns a lazy sequence of list of n items.
        /// </returns>
        public static IEnumerable<T[]> partition<T>(int n, IEnumerable<T> coll) => partition(n, n, coll);

        /// <summary>
        /// Returns a lazy sequence of list of n items each, at offsets step apart. If step is not supplied, 
        /// defaults to n, i.e. the partitions do not overlap.
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="n">The number of items to partition the <see cref="IEnumerable{T}"/> into.</param>
        /// <param name="step">the offset to start each partition by.</param>
        /// <param name="coll">The <see cref="IEnumerable{T}"/> being partitioned.</param>
        /// <returns>
        /// Returns a lazy sequence of list of n items.
        /// </returns>
        public static IEnumerable<T[]> partition<T>(int n, int step, IEnumerable<T> coll) => 
            lazyseq(() => whenlet(seq(coll),
                s => let(
                    take(n, s),
                    p => when(n == count(p),
                        () => cons(toarray(p), partition(n, step, nthrest(s, step)))))));
    }
}
