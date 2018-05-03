namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Main namespace for the funx library.
    /// </summary>
    public static partial class core
    {
        #region inc
        /// <summary>
        /// Increases the number by one greater.
        /// </summary>
        /// <param name="x">The <see cref="long"/> to increase by 1.</param>
        /// <returns>
        /// Returns a number one greater.
        /// </returns>
        public static long inc(long x) => ++x;

        /// <summary>
        /// Increases the number by one greater.
        /// </summary>
        /// <param name="x">The <see cref="int"/> to increase by 1.</param>
        /// <returns>
        /// Returns a number one greater.
        /// </returns>
        public static int inc(int x) => ++x;

        /// <summary>
        /// Increases the number by one greater.
        /// </summary>
        /// <param name="x">The <see cref="double"/> to increase by 1.</param>
        /// <returns>
        /// Returns a number one greater.
        /// </returns>
        public static double inc(double x) => ++x;

        /// <summary>
        /// Increases the number by one greater.
        /// </summary>
        /// <param name="x">The <see cref="float"/> to increase by 1.</param>
        /// <returns>
        /// Returns a number one greater.
        /// </returns>
        public static float inc(float x) => ++x;
        #endregion

        #region dec
        /// <summary>
        /// Decreases the number by one smaller.
        /// </summary>
        /// <param name="x">The <see cref="long"/> to decreases by 1.</param>
        /// <returns>
        /// Returns a number one smaller.
        /// </returns>
        public static long dec(long x) => --x;

        /// <summary>
        /// Decreases the number by one smaller.
        /// </summary>
        /// <param name="x">The <see cref="int"/> to decreases by 1.</param>
        /// <returns>
        /// Returns a number one smaller.
        /// </returns>
        public static int dec(int x) => --x;

        /// <summary>
        /// Decreases the number by one smaller.
        /// </summary>
        /// <param name="x">The <see cref="double"/> to decreases by 1.</param>
        /// <returns>
        /// Returns a number one smaller.
        /// </returns>
        public static double dec(double x) => --x;

        /// <summary>
        /// Decreases the number by one smaller.
        /// </summary>
        /// <param name="x">The <see cref="float"/> to decreases by 1.</param>
        /// <returns>
        /// Returns a number one smaller.
        /// </returns>
        public static float dec(float x) => --x;
        #endregion

        #region Iterate
        /// <summary>
        /// Returns a lazy sequence of x, func(x), func(func(x)) etc. func must be free of side-effects.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="func">The function to iterate over.</param>
        /// <param name="x">The starting value.</param>
        /// <returns>
        /// Returns a lazy sequence.
        /// </returns>
        public static IEnumerable<T> iterate<T>(Func<T, T> func, T x)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));

            while (true)
            {
                yield return x;
                x = func(x);
            }
        }
        #endregion
    }
}
