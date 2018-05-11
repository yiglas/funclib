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
        static Random _random = new Random();

        /// <summary>
        /// Returns a random double number between 0 (inclusive) and n (default 1) (exclusive
        /// </summary>
        /// <returns>
        /// Returns a random number between 0 and 1
        /// </returns>
        public static double rand()
        {
            lock (_random)
            {
                return _random.NextDouble();
            }
        }

        /// <summary>
        /// Returns a random double number between 0 (inclusive) and n (default 1) (exclusive
        /// </summary>
        /// <param name="n">Upper bound of the random number.</param>
        /// <returns>
        /// Returns a random number between 0 and 1
        /// </returns>
        public static double rand(double n) => n * rand();
    }
}
