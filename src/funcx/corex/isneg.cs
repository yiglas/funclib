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
        /// Returns true if n is less than zero.
        /// </summary>
        /// <param name="n">The <see cref="long"/> to test.</param>
        /// <returns>
        /// true if n is less than zero, otherwise false.
        /// </returns>
        public static bool isneg(long n) => n < 0;

        /// <summary>
        /// Returns true if n is less than zero.
        /// </summary>
        /// <param name="n">The <see cref="int"/> to test.</param>
        /// <returns>
        /// true if n is less than zero, otherwise false.
        /// </returns>
        public static bool isneg(int n) => n < 0;

        /// <summary>
        /// Returns true if n is less than zero.
        /// </summary>
        /// <param name="n">The <see cref="double"/> to test.</param>
        /// <returns>
        /// true if n is less than zero, otherwise false.
        /// </returns>
        public static bool isneg(double n) => n < 0;

        /// <summary>
        /// Returns true if n is less than zero.
        /// </summary>
        /// <param name="n">The <see cref="float"/> to test.</param>
        /// <returns>
        /// true if n is less than zero, otherwise false.
        /// </returns>
        public static bool isneg(float n) => n < 0;
    }
}
