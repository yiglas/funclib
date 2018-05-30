namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        // TODO: add more number types


        /// <summary>
        /// Returns true if n is odd
        /// </summary>
        /// <param name="n">The <see cref="long"/> to test.</param>
        /// <returns>
        /// true if n is odd, otherwise false.
        /// </returns>
        public static bool isodd(long n) => (n % 2) != 0;

        /// <summary>
        /// Returns true if n is odd
        /// </summary>
        /// <param name="n">The <see cref="int"/> to test.</param>
        /// <returns>
        /// true if n is odd, otherwise false.
        /// </returns>
        public static bool isodd(int n) => (n % 2) != 0;

        /// <summary>
        /// Returns true if n is odd
        /// </summary>
        /// <param name="n">The <see cref="double"/> to test.</param>
        /// <returns>
        /// true if n is odd, otherwise false.
        /// </returns>
        public static bool isodd(double n) => (n % 2) != 0;

        /// <summary>
        /// Returns true if n is odd
        /// </summary>
        /// <param name="n">The <see cref="float"/> to test.</param>
        /// <returns>
        /// true if n is odd, otherwise false.
        /// </returns>
        public static bool isodd(float n) => (n % 2) != 0;
    }
}
