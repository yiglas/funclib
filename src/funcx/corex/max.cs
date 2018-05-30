namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns the larger <see cref="int"/>, with only one parameter it returns that parameter
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <returns>
        /// Parameter x
        /// </returns>
        public static int max(int x) => x;

        /// <summary>
        /// Returns the larger of two <see cref="int"/>.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <returns>
        /// Parameter x or y, whichever is larger.
        /// </returns>
        public static int max(int x, int y) => Math.Max(x, y);

        /// <summary>
        /// Returns the larger of all <see cref="int"/> parameters.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <param name="more">The rest of the parameters.</param>
        /// <returns>
        /// Returns the largest <see cref="int"/>.
        /// </returns>
        public static int max(int x, int y, params int[] more) => Util.Reduce1(max, max(x, y), more);
        
        /// <summary>
        /// Returns the larger <see cref="long"/>, with only one parameter it returns that parameter
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <returns>
        /// Parameter x
        /// </returns>
        public static long max(long x) => x;

        /// <summary>
        /// Returns the larger of two <see cref="long"/>.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <returns>
        /// Parameter x or y, whichever is larger.
        /// </returns>
        public static long max(long x, long y) => Math.Max(x, y);

        /// <summary>
        /// Returns the larger of all <see cref="long"/> parameters.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <param name="more">The rest of the parameters.</param>
        /// <returns>
        /// Returns the largest <see cref="long"/>.
        /// </returns>
        public static long max(long x, long y, params long[] more) => Util.Reduce1(max, max(x, y), more);
        
        /// <summary>
        /// Returns the larger <see cref="double"/>, with only one parameter it returns that parameter
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <returns>
        /// Parameter x
        /// </returns>
        public static double max(double x) => x;

        /// <summary>
        /// Returns the larger of two <see cref="double"/>.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <returns>
        /// Parameter x or y, whichever is larger.
        /// </returns>
        public static double max(double x, double y) => Math.Max(x, y);

        /// <summary>
        /// Returns the larger of all <see cref="double"/> parameters.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <param name="more">The rest of the parameters.</param>
        /// <returns>
        /// Returns the largest <see cref="double"/>.
        /// </returns>
        public static double max(double x, double y, params double[] more) => Util.Reduce1(max, max(x, y), more);
        
        /// <summary>
        /// Returns the larger <see cref="float"/>, with only one parameter it returns that parameter
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <returns>
        /// Parameter x
        /// </returns>
        public static float max(float x) => x;

        /// <summary>
        /// Returns the larger of two <see cref="float"/>.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <returns>
        /// Parameter x or y, whichever is larger.
        /// </returns>
        public static float max(float x, float y) => Math.Max(x, y);

        /// <summary>
        /// Returns the larger of all <see cref="float"/> parameters.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <param name="more">The rest of the parameters.</param>
        /// <returns>
        /// Returns the largest <see cref="float"/>.
        /// </returns>
        public static float max(float x, float y, params float[] more) => Util.Reduce1(max, max(x, y), more);
    }
}
