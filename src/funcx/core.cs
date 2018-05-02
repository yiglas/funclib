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
    }
}
