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

        #region truthy
        /// <summary>
        /// Returns true if object is bool and true or object is not null.
        /// </summary>
        /// <param name="source">The <see cref="object"/> checking to is an object.</param>
        /// <returns>
        /// true if object is bool and true or not null, otherwise false.
        /// </returns>
        public static bool truthy(object source) => !falsy(source);
        #endregion

        #region falsy
        /// <summary>
        /// Returns true if object is bool and false or object is null.
        /// </summary>
        /// <param name="source">The <see cref="object"/> checking to is an object.</param>
        /// <returns>
        /// true if object is bool and false or null, otherwise false.
        /// </returns>
        public static bool falsy(object source)
        {
            if (source == null) return true;
            else if (source is bool && !(bool)source) return true;
            else return false;
        }
        #endregion
    }
}
