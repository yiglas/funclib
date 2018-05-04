using System;
using System.Collections.Generic;
using System.Text;

namespace funcx
{
    /// <summary>
    /// Compares two items using a <see cref="Func{T1, T2, TResult}"/> with the TResult a boolean.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam>
    class FunctionComparer<T> : IComparer<T>
    {
        Func<T, T, bool> _comparator;

        public FunctionComparer(Func<T, T, bool> comparator)
        {
            this._comparator = comparator;
        }

        public int Compare(T x, T y) => this._comparator(x, y) ? 0 : 1;
    }
}
