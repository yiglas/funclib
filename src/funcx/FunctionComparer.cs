using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary
{
    /// <summary>
    /// Compares two items using a <see cref="Func{T1, T2, TResult}"/> with the TResult a boolean.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam>
    class FunctionComparer<T> : IComparer<T>
    {
        Func<T, T, int> _comparator;

        public FunctionComparer(Func<T, T, int> comparator)
        {
            this._comparator = comparator;
        }

        public int Compare(T x, T y) => this._comparator(x, y);
    }
}
