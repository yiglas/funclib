using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of numbers from start (inclusive) to end
    /// (Exclusive), by step, where start defaults to 0, step to 1, and end to
    /// infinity. When step is equal to 0, returns an infinite sequence of
    /// start. When start is equal to end, returns empty list.
    /// </summary>
    public class Range :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of numbers from start (inclusive) to end
        /// (Exclusive), by step, where start defaults to 0, step to 1, and end to
        /// infinity. When step is equal to 0, returns an infinite sequence of
        /// start. When start is equal to end, returns empty list.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="Collections.Iterate"/> collection starting at 0 continues infinitly.
        /// </returns>
        public object Invoke() => iterate(new Inc(), 0);
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of numbers from start (inclusive) to end
        /// (Exclusive), by step, where start defaults to 0, step to 1, and end to
        /// infinity. When step is equal to 0, returns an infinite sequence of
        /// start. When start is equal to end, returns empty list.
        /// </summary>
        /// <param name="end">Either a <see cref="long"/> or <see cref="int"/> value to identify the end value.</param>
        /// <returns>
        /// Returns either <see cref="Collections.LongRange"/> if end is <see cref="long"/> or <see cref="Collections.Range"/> if end
        /// is <see cref="int"/>.
        /// </returns>
        public object Invoke(object end) =>
            end is long e
                ? Collections.LongRange.Create(e)
                : Collections.Range.Create(end);
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of numbers from start (inclusive) to end
        /// (Exclusive), by step, where start defaults to 0, step to 1, and end to
        /// infinity. When step is equal to 0, returns an infinite sequence of
        /// start. When start is equal to end, returns empty list.
        /// </summary>
        /// <param name="start">Either a <see cref="long"/> or <see cref="int"/> value to identify the start value.</param>
        /// <param name="end">Either a <see cref="long"/> or <see cref="int"/> value to identify the end value.</param>
        /// <returns>
        /// Returns either <see cref="Collections.LongRange"/> if end/start is <see cref="long"/> or <see cref="Collections.Range"/> if end/start
        /// is <see cref="int"/>.
        /// </returns>
        public object Invoke(object start, object end) => 
            start is long s && end is long e
                ? Collections.LongRange.Create(s, e)
                : Collections.Range.Create(start, end);

        /// <summary>
        /// Returns a <see cref="LazySeq"/> of numbers from start (inclusive) to end
        /// (Exclusive), by step, where start defaults to 0, step to 1, and end to
        /// infinity. When step is equal to 0, returns an infinite sequence of
        /// start. When start is equal to end, returns empty list.
        /// </summary>
        /// <param name="start">Either a <see cref="long"/> or <see cref="int"/> value to identify the start value.</param>
        /// <param name="end">Either a <see cref="long"/> or <see cref="int"/> value to identify the end value.</param>
        /// <param name="step">Either a <see cref="long"/> or <see cref="int"/> value to identify the step value.</param>
        /// <returns>
        /// Returns either <see cref="Collections.LongRange"/> if end/start/step is <see cref="long"/> or <see cref="Collections.Range"/> if end/start/step
        /// is <see cref="int"/>.
        /// </returns>
        public object Invoke(object start, object end, object step) =>
            start is long s && end is long e && step is long p
                ? Collections.LongRange.Create(s, e, p)
                : Collections.Range.Create(start, end, step);
    }
}
