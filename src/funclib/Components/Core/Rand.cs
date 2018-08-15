using funclib.Components.Core.Generic;
using System;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Random"/> floating point number between 
    /// 0 (inclusive) and n (default 1) (exclusive).
    /// </summary>
    public class Rand :
        IFunction<object>,
        IFunction<object, object>
    {
        static readonly Random _random = new Random();

        /// <summary>
        /// Returns a <see cref="Random"/> floating point number between 
        /// 0 (inclusive) and n (default 1) (exclusive).
        /// </summary>
        /// <returns>
        /// Returns a <see cref="Random"/> floating point number between 
        /// 0 (inclusive) and n (default 1) (exclusive).
        /// </returns>
        public object Invoke() => new Locking(_random, () => _random.NextDouble()).Invoke();
        /// <summary>
        /// Returns a <see cref="Random"/> floating point number between 
        /// 0 (inclusive) and n (default 1) (exclusive).
        /// </summary>
        /// <param name="n">An <see cref="int"/> for the exclusive value.</param>
        /// <returns>
        /// Returns a <see cref="Random"/> floating point number between 
        /// 0 (inclusive) and n (default 1) (exclusive).
        /// </returns>
        public object Invoke(object n) => Numbers.Multiply(n, Invoke());
    }
}
