namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns the smaller <see cref="int"/>, with only one parameter it returns that parameter
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <returns>
        /// Parameter x
        /// </returns>
        public static int min(int x) => x;

        /// <summary>
        /// Returns the smaller of two <see cref="int"/>.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <returns>
        /// Parameter x or y, whichever is smaller.
        /// </returns>
        public static int min(int x, int y) => Math.Min(x, y);

        /// <summary>
        /// Returns the smaller of all <see cref="int"/> parameters.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <param name="more">The rest of the parameters.</param>
        /// <returns>
        /// Returns the smallest <see cref="int"/>.
        /// </returns>
        public static int min(int x, int y, params int[] more) => Util.Reduce1(min, min(x, y), more);

        /// <summary>
        /// Returns the smaller <see cref="long"/>, with only one parameter it returns that parameter
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <returns>
        /// Parameter x
        /// </returns>
        public static long min(long x) => x;

        /// <summary>
        /// Returns the smaller of two <see cref="long"/>.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <returns>
        /// Parameter x or y, whichever is smaller.
        /// </returns>
        public static long min(long x, long y) => Math.Min(x, y);

        /// <summary>
        /// Returns the smaller of all <see cref="long"/> parameters.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <param name="more">The rest of the parameters.</param>
        /// <returns>
        /// Returns the smallest <see cref="long"/>.
        /// </returns>
        public static long min(long x, long y, params long[] more) => Util.Reduce1(min, min(x, y), more);

        /// <summary>
        /// Returns the smaller <see cref="double"/>, with only one parameter it returns that parameter
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <returns>
        /// Parameter x
        /// </returns>
        public static double min(double x) => x;

        /// <summary>
        /// Returns the smaller of two <see cref="double"/>.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <returns>
        /// Parameter x or y, whichever is smaller.
        /// </returns>
        public static double min(double x, double y) => Math.Min(x, y);

        /// <summary>
        /// Returns the smaller of all <see cref="double"/> parameters.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <param name="more">The rest of the parameters.</param>
        /// <returns>
        /// Returns the smallest <see cref="double"/>.
        /// </returns>
        public static double min(double x, double y, params double[] more) => Util.Reduce1(min, min(x, y), more);

        /// <summary>
        /// Returns the smaller <see cref="float"/>, with only one parameter it returns that parameter
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <returns>
        /// Parameter x
        /// </returns>
        public static float min(float x) => x;

        /// <summary>
        /// Returns the smaller of two <see cref="float"/>.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <returns>
        /// Parameter x or y, whichever is smaller.
        /// </returns>
        public static float min(float x, float y) => Math.Min(x, y);

        /// <summary>
        /// Returns the smaller of all <see cref="float"/> parameters.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter.</param>
        /// <param name="more">The rest of the parameters.</param>
        /// <returns>
        /// Returns the smallest <see cref="float"/>.
        /// </returns>
        public static float min(float x, float y, params float[] more) => Util.Reduce1(min, min(x, y), more);
    }
}
