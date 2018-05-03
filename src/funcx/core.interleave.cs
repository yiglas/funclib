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
        /// Returns a lazy sequence of the first item in the <see cref="IEnumerable{T}"/>, then the second etc.
        /// </summary>
        /// <typeparam name="T">Generic type of the collection.</typeparam>
        /// <param name="c1">The <see cref="IEnumerable{T}"/> object.</param>
        /// <returns>
        /// Returns a lazy <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<object> interleave<T>(IEnumerable<T> c1)
        {
            if (c1 == null) yield break;

            var e1 = c1.GetEnumerator();

            while (e1.MoveNext())
            {
                yield return e1.Current;
            }
        }

        /// <summary>
        /// Returns a lazy sequence of the first item in each <see cref="IEnumerable{T}"/>, then the second etc.
        /// </summary>
        /// <typeparam name="T1">Generic type of the collection.</typeparam>
        /// <typeparam name="T2">Generic type of the collection.</typeparam>
        /// <param name="c1">The <see cref="IEnumerable{T}"/> object.</param>
        /// <param name="c2">The <see cref="IEnumerable{T}"/> object.</param>
        /// <returns>
        /// Returns a lazy <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<object> interleave<T1, T2>(IEnumerable<T1> c1, IEnumerable<T2> c2)
        {
            if (c1 == null || c2 == null) yield break;

            var e1 = c1.GetEnumerator();
            var e2 = c2.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {
                yield return e1.Current;
                yield return e2.Current;
            }
        }

        /// <summary>
        /// Returns a lazy sequence of the first item in each <see cref="IEnumerable{T}"/>, then the second etc.
        /// </summary>
        /// <typeparam name="T1">Generic type of the collection.</typeparam>
        /// <typeparam name="T2">Generic type of the collection.</typeparam>
        /// <typeparam name="T3">Generic type of the collection.</typeparam>
        /// <param name="c1">The <see cref="IEnumerable{T}"/> object.</param>
        /// <param name="c2">The <see cref="IEnumerable{T}"/> object.</param>
        /// <param name="c3">The <see cref="IEnumerable{T}"/> object.</param>
        /// <returns>
        /// Returns a lazy <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<object> interleave<T1, T2, T3>(IEnumerable<T1> c1, IEnumerable<T2> c2, IEnumerable<T3> c3)
        {
            if (c1 == null || c2 == null || c3 == null) yield break;

            var e1 = c1.GetEnumerator();
            var e2 = c2.GetEnumerator();
            var e3 = c3.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
            {
                yield return e1.Current;
                yield return e2.Current;
                yield return e3.Current;
            }
        }

        //TODO add method for interleave: interleave(c1, c2, c3, params [] c4)
    }
}
