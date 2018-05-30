namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Return a lazy infinite sequence starting at 0.
        /// </summary>
        /// <returns>
        /// Infinite lazy sequence.
        /// </returns>
        public static IEnumerable<long> range() => iterate<long>(inc, 0);

        /// <summary>
        /// Returns a lazy sequence starting at 0 to end (exclusive)
        /// </summary>
        /// <param name="end">Where to end the sequence.</param>
        /// <returns>
        /// Returns a lazy sequence to end.
        /// </returns>
        public static IEnumerable<long> range(long end)
        {
            int start = 0;
            while (start < end)
            {
                yield return start;
                start = inc(start);
            }
        }

        /// <summary>
        /// Returns a lazy sequence of numbers from start (inclusive) to end
        /// (exclusive). When start equals end or end is less then start returns
        /// an empty list.
        /// </summary>
        /// <param name="start">The value of the first number in the sequence.</param>
        /// <param name="end">Where to end the sequence.</param>
        /// <returns>
        /// Returns a lazy sequence start to end.
        /// </returns>
        public static IEnumerable<long> range(long start, long end)
        {
            if (start == end || end < start) yield break;
            while (start < end)
            {
                yield return start;
                start = inc(start);
            }
        }

        /// <summary>
        /// Returns a lazy sequence of numbers from start (inclusive) to end
        /// (exclusive). When start equals end or end is less then start returns
        /// an empty list. If step equals zero returns a infinite sequence of start.
        /// </summary>
        /// <param name="start">The value of the first number in the sequence.</param>
        /// <param name="end">Where to end the sequence.</param>
        /// <param name="step">The step to take on each loop.</param>
        /// <returns>
        /// Returns a lazy sequence start to end by step.
        /// </returns>
        public static IEnumerable<long> range(long start, long end, long step)
        {
            if (start == end || end < start) yield break;
            while (start < end)
            {
                yield return start;
                start = start + step;
            }
        }
    }
}
