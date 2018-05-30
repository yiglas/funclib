namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// f should be a function of 2 arguments that returns the result of applying f to the first 2 items in coll,
        /// then applying f to that result and the 3rd item, etc. If coll contains no items, f must accept the default arguments
        /// as well, and reduce returns the result of calling f with default arguments.
        /// as well
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="f">An accumulator function to be invoked on each element.</param>
        /// <param name="coll">An <see cref="IEnumerable{T}"/> to aggregate over.</param>
        /// <returns>The final accumulator value.</returns>
        public static TSource reduce<TSource>(Func<TSource, TSource, TSource> f, IEnumerable<TSource> coll) =>
            coll == null || !coll.Any()
                ? f(default, default)
                : coll.Aggregate(f);

        /// <summary>
        /// f should be a function of 2 arguments that returns the result of applying f to the first 2 items in coll,
        /// then applying f to that result and the 3rd item, etc. If coll contains no items, f must accept the default arguments
        /// as well, and reduce returns the result of calling f with default arguments.
        /// as well
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
        /// <param name="f">An accumulator function to be invoked on each element.</param>
        /// <param name="val">The initial accumulator value.</param>
        /// <param name="coll">An <see cref="IEnumerable{T}"/> to aggregate over.</param>
        /// <returns>The final accumulator value.</returns>
        public static TAccumulate reduce<TSource, TAccumulate>(Func<TAccumulate, TSource, TAccumulate> f, TAccumulate val, IEnumerable<TSource> coll) =>
            coll == null || !coll.Any()
                ? val
                : coll.Aggregate(val, f);
    }
}
