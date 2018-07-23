using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if values are equal, otherwise <see cref="false"/>.
    /// </summary>
    public class IsEqualTo :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if values are equal, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <returns>
        /// Always true.
        /// </returns>
        public object Invoke(object x) => true;
        /// <summary>
        /// Returns <see cref="true"/> if values are equal, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test against.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is equal to y, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x, object y)
        {
            if (x == y) return true;
            if (x != null)
            {
                if (Numbers.IsNumber(x) && Numbers.IsNumber(y))
                    return Numbers.IsEqual(x, y);

                return x.Equals(y);
            }

            return false;
        }
        /// <summary>
        /// Returns <see cref="true"/> if values are equal, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test against.</param>
        /// <param name="more">All other elements to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if values are equal, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x, object y, params object[] more)
        {
            if ((bool)Invoke(x, y))
            {
                var n = next(more);
                if ((bool)new Truthy().Invoke(n))
                    return Invoke(y, first(more), (object[])toArray(n));

                return Invoke(y, first(more));
            }

            return false;
        }
    }
}
