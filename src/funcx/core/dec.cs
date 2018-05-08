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
    }
}
