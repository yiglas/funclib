using funclib.Components.Core.Generic;
using System;

namespace funclib.Components.Core
{
    /// <summary>
    /// Comparator, that returns a negative number, zero, or positive number when x
    /// is logically 'less than', 'equal to' or 'greater than' y. Same as 
    /// <see cref="IComparable.CompareTo(object)"/> except it works for null and 
    /// compares numbers and collections in a type-independent manner.
    /// </summary>
    public class Compare :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Comparator, that returns a negative number, zero, or positive number when x
        /// is logically 'less than', 'equal to' or 'greater than' y. Same as 
        /// <see cref="IComparable.CompareTo(object)"/> except it works for null and 
        /// compares numbers and collections in a type-independent manner.
        /// </summary>
        /// <param name="x">Object that is either null, number or implements the <see cref="IComparable"/> interface.</param>
        /// <param name="y">Other that is eitehr null, number or an object to test.</param>
        /// <returns>
        /// Returns a <see cref="int"/> thats a negative number when  x 'less than' y, zero when x 'equal to' y or positive number
        /// x 'greater than' y.
        /// </returns>
        public object Invoke(object x, object y)
        {
            if (x == y) return 0;
            if (x != null)
            {
                if (y is null) return 1;
                if (Numbers.IsNumber(x) && Numbers.IsNumber(y))
                    return Numbers.Compare(x, y);

                return ((IComparable)x).CompareTo(y);
            }

            return -1;
        }
    }
}
