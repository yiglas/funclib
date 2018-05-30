namespace FunctionalLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns a lazy <see cref="IEnumerable{T}"/> representing the concatenation of the elements in the supplied colls
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <returns>
        /// Returns an empty <see cref="IEnumerable{T}"/>.
        /// </returns>
        public static IEnumerable<T> concat<T>()
        {
            yield break;
        }

        /// <summary>
        /// Returns a lazy <see cref="IEnumerable{T}"/> representing the concatenation of the elements in the supplied colls
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="x">The <see cref="IEnumerable{T}"/> object.</param>
        /// <returns>
        /// Returns the <see cref="IEnumerable{T}"/> passed in.
        /// </returns>
        public static IEnumerable<T> concat<T>(IEnumerable<T> x)
        {
            if (x == null) yield break;

            foreach (var item in x)
                yield return item;
        }
        
        /// <summary>
        /// Returns a lazy <see cref="IEnumerable{T}"/> representing the concatenation of the elements in the supplied colls
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="x">The <see cref="IEnumerable{T}"/> to first iterate through.</param>
        /// <param name="y">The next <see cref="IEnumerable{T}"/> to iterate through.</param>
        /// <returns>
        /// Returns the concatenation of passed in <see cref="IEnumerable{T}"/>.
        /// </returns>
        public static IEnumerable<T> concat<T>(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (x != null)
                foreach (var item in x)
                    yield return item;

            if (y != null)
                foreach (var item in y)
                    yield return item;
        }

        /// <summary>
        /// Returns a lazy <see cref="IEnumerable{T}"/> representing the concatenation of the elements in the supplied colls
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="x">The <see cref="IEnumerable{T}"/> to first iterate through.</param>
        /// <param name="y">The next <see cref="IEnumerable{T}"/> to iterate through.</param>
        /// <param name="zs">The rest of the <see cref="IEnumerable{T}"/> to iterate through.</param>
        /// <returns>
        /// Returns the concatenation of passed in <see cref="IEnumerable{T}"/>.
        /// </returns>
        public static IEnumerable<T> concat<T>(IEnumerable<T> x, IEnumerable<T> y, params IEnumerable<T>[] zs)
        {
            if (x != null)
                foreach (var item in x)
                    yield return item;

            if (y != null)
                foreach (var item in y)
                    yield return item;

            for (int i = 0; i < zs.Length; i++)
                if (zs[i] != null)
                    foreach (var item in zs[i])
                        yield return item;
        }
    }
}
