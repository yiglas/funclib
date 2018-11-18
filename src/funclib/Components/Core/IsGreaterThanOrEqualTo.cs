using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a true, numbers are monotonically non-increasing order, otherwise false.
    /// </summary>
    public class IsGreaterThanOrEqualTo :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns a true, numbers are monotonically non-increasing order, otherwise false.
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <returns>
        /// Returns true.
        /// </returns>
        public object Invoke(object x) => true;
        /// <summary>
        /// Returns a true, numbers are monotonically non-increasing order, otherwise false.
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test.</param>
        /// <returns>
        /// Returns a true, numbers are monotonically non-increasing order, otherwise false.
        /// </returns>
        public object Invoke(object x, object y) => Numbers.IsGTE(x, y);
        /// <summary>
        /// Returns a true, numbers are monotonically non-increasing order, otherwise false.
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test.</param>
        /// <param name="more">Rest of the elements to test.</param>
        /// <returns>
        /// Returns a true, numbers are monotonically non-increasing order, otherwise false.
        /// </returns>
        public object Invoke(object x, object y, params object[] more)
        {
            if ((bool)Invoke(x, y))
            {
                var n = funclib.Core.Next(more);
                if ((bool)funclib.Core.Truthy(n))
                    return Invoke(y, funclib.Core.First(more), (object[])funclib.Core.ToArray(n));

                return Invoke(y, funclib.Core.First(more));
            }

            return false;
        }
    }
}
