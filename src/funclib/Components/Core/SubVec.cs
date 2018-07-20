using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="IVector"/> of the items in <see cref="IVector"/> from start (inclusive)
    /// to end (exclusive). If end is not supplied, default to <see cref="Count"/> of <see cref="IVector"/>.
    /// </summary>
    public class SubVec :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="IVector"/> of the items in <see cref="IVector"/> from start (inclusive)
        /// to end (exclusive). If end is not supplied, default to <see cref="Count"/> of <see cref="IVector"/>.
        /// </summary>
        /// <param name="v">An object that implements the <see cref="IVector"/> interface.</param>
        /// <param name="start">The zero-based starting index position.</param>
        /// <returns>
        /// Returns a <see cref="IVector"/> of the items in <see cref="IVector"/> from start (inclusive)
        /// to end (exclusive). If end is not supplied, default to <see cref="Count"/> of <see cref="IVector"/>.
        /// </returns>
        public object Invoke(object v, object start) => Invoke(v, start, new Count().Invoke(v));
        /// <summary>
        /// Returns a <see cref="IVector"/> of the items in <see cref="IVector"/> from start (inclusive)
        /// to end (exclusive). If end is not supplied, default to <see cref="Count"/> of <see cref="IVector"/>.
        /// </summary>
        /// <param name="v">An object that implements the <see cref="IVector"/> interface.</param>
        /// <param name="start">The zero-based starting index position.</param>
        /// <param name="end">The number of items.</param>
        /// <returns>
        /// Returns a <see cref="IVector"/> of the items in <see cref="IVector"/> from start (inclusive)
        /// to end (exclusive). If end is not supplied, default to <see cref="Count"/> of <see cref="IVector"/>.
        /// </returns>
        public object Invoke(object v, object start, object end)
        {
            var vec = (IVector)v;

            var s = (int)start;
            if (s < 0) throw new ArgumentOutOfRangeException(nameof(start), $"{nameof(start)} cannot be less than zero.");

            var e = (int)end;
            if (e < s) throw new ArgumentOutOfRangeException(nameof(end), $"{nameof(end)} cannot be less than {nameof(start)}.");
            if (e > vec.Count) throw new ArgumentOutOfRangeException(nameof(end), $"{nameof(end)} cannot be greater than the end of the vector.");

            if (s == e) return Collections.Vector.EMPTY;

            return SubVector.Create(vec, s, e);
        }
    }
}
