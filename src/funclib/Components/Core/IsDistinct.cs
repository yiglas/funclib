using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if no two arguments are equal, otherwise <see cref="false"/>.
    /// </summary>
    public class IsDistinct :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if no two arguments are equal, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">Other to test.</param>
        /// <returns>
        /// Always returns <see cref="true"/>.
        /// </returns>
        public object Invoke(object x) => true;
        /// <summary>
        /// Returns <see cref="true"/> if no two arguments are equal, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">First object to test.</param>
        /// <param name="y">Second object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if no two arguments are equal, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x, object y) => new Not().Invoke(new IsEqualTo().Invoke(x, y));
        /// <summary>
        /// Returns <see cref="true"/> if no two arguments are equal, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">First object to test.</param>
        /// <param name="y">Second object to test.</param>
        /// <param name="more">Rest of the objects to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if no two arguments are equal, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x, object y, params object[] more)
        {
            if ((bool)new IsNotEqual().Invoke(x, y))
                return loop(new HashSet().Invoke(x, y), more);

            return false;
            
            object loop(object s, object xs)
            {
                var f = new First().Invoke(xs);
                var etc = new Seq().Invoke(new Rest().Invoke(xs));

                if ((bool)new Truthy().Invoke(xs))
                {
                    if ((bool)contains(s, f))
                        return false;

                    return loop(conj(s, f), etc);
                }
                else return true;
            }
        }
    }
}
