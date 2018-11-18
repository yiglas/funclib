using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if no two arguments are equal, otherwise false.
    /// </summary>
    public class IsDistinct :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns true if no two arguments are equal, otherwise false.
        /// </summary>
        /// <param name="x">Other to test.</param>
        /// <returns>
        /// Always returns true.
        /// </returns>
        public object Invoke(object x) => true;
        /// <summary>
        /// Returns true if no two arguments are equal, otherwise false.
        /// </summary>
        /// <param name="x">First object to test.</param>
        /// <param name="y">Second object to test.</param>
        /// <returns>
        /// Returns true if no two arguments are equal, otherwise false.
        /// </returns>
        public object Invoke(object x, object y) => funclib.Core.Not(funclib.Core.IsEqualTo(x, y));
        /// <summary>
        /// Returns true if no two arguments are equal, otherwise false.
        /// </summary>
        /// <param name="x">First object to test.</param>
        /// <param name="y">Second object to test.</param>
        /// <param name="more">Rest of the objects to test.</param>
        /// <returns>
        /// Returns true if no two arguments are equal, otherwise false.
        /// </returns>
        public object Invoke(object x, object y, params object[] more) => (bool)funclib.Core.IsNotEqualTo(x, y) ? loop(funclib.Core.HashSet(x, y), more) : false;

        static object loop(object s, object xs)
        {
            var f = funclib.Core.First(xs);
            var etc = funclib.Core.Seq(funclib.Core.Rest(xs));

            if ((bool)funclib.Core.Truthy(xs))
            {
                if ((bool)funclib.Core.Contains(s, f))
                    return false;

                return loop(funclib.Core.Conj(s, f), etc);
            }
            else return true;
        }
    }
}
