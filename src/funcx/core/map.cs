namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns a lazy sequence consisting of the result of applying func to the first item
        /// in the <see cref="IEnumerable{T}"/>, followed by applying func to the second item in
        /// the <see cref="IEnumerable{T}"/>, until the <see cref="IEnumerable{T}"/> is exhausted.
        /// </summary>
        /// <typeparam name="T">Generic type of the collection.</typeparam>
        /// <typeparam name="R">Generic type of the return collection.</typeparam>
        /// <param name="func">The function to run on every item in the list</param>
        /// <param name="coll">The <see cref="IEnumerable{T}"/> object.</param>
        /// <returns>
        /// Returns a lazy <see cref="IEnumerable{T}"/>.
        /// </returns>
        public static IEnumerable<R> map<T, R>(Func<T, R> func, IEnumerable<T> coll)
        {
            if (coll == null) yield break;
            if (func == null) throw new ArgumentNullException(nameof(func));

            var e1 = coll.GetEnumerator();

            while (e1.MoveNext())
                yield return func(e1.Current);
        }

        /// <summary>
        /// Returns a lazy sequence consisting of the result of applying func to the first items
        /// of each <see cref="IEnumerable{T}"/>, followed by applying func to the second items of
        /// each <see cref="IEnumerable{T}"/>, until the <see cref="IEnumerable{T}"/> is exhausted.
        /// </summary>
        /// <typeparam name="T1">Generic type of the collection.</typeparam>
        /// <typeparam name="T2">Generic type of the collection.</typeparam>
        /// <typeparam name="R">Generic type of the return collection.</typeparam>
        /// <param name="func">The function to run on every item in the list</param>
        /// <param name="c1">The <see cref="IEnumerable{T}"/> object.</param>
        /// <param name="c2">The <see cref="IEnumerable{T}"/> object.</param>
        /// <returns>
        /// Returns a lazy <see cref="IEnumerable{T}"/>.
        /// </returns>
        public static IEnumerable<R> map<T1, T2, R>(Func<T1, T2, R> func, IEnumerable<T1> c1, IEnumerable<T2> c2)
        {
            if (c1 == null || c2 == null) yield break;
            if (func == null) throw new ArgumentNullException(nameof(func));

            var e1 = c1.GetEnumerator();
            var e2 = c2.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
                yield return func(e1.Current, e2.Current);
        }

        /// <summary>
        /// Returns a lazy sequence consisting of the result of applying func to the first items
        /// of each <see cref="IEnumerable{T}"/>, followed by applying func to the second items of
        /// each <see cref="IEnumerable{T}"/>, until the <see cref="IEnumerable{T}"/> is exhausted.
        /// </summary>
        /// <typeparam name="T1">Generic type of the collection.</typeparam>
        /// <typeparam name="T2">Generic type of the collection.</typeparam>
        /// <typeparam name="T3">Generic type of the collection.</typeparam>
        /// <typeparam name="R">Generic type of the return collection.</typeparam>
        /// <param name="func">The function to run on every item in the list</param>
        /// <param name="c1">The <see cref="IEnumerable{T}"/> object.</param>
        /// <param name="c2">The <see cref="IEnumerable{T}"/> object.</param>
        /// <param name="c3">The <see cref="IEnumerable{T}"/> object.</param>
        /// <returns>
        /// Returns a lazy <see cref="IEnumerable{T}"/>.
        /// </returns>
        public static IEnumerable<R> map<T1, T2, T3, R>(Func<T1, T2, T3, R> func, IEnumerable<T1> c1, IEnumerable<T2> c2, IEnumerable<T3> c3)
        {
            if (c1 == null || c2 == null || c3 == null) yield break;
            if (func == null) throw new ArgumentNullException(nameof(func));

            var e1 = c1.GetEnumerator();
            var e2 = c2.GetEnumerator();
            var e3 = c3.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
                yield return func(e1.Current, e2.Current, e3.Current);
        }

        //TODO add method for map: map(func, c1, c2, c3, params [] c4)
    }
}
