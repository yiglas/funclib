using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the nth rest of coll, coll when n is 0.
    /// </summary>
    public class NthRest :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns the nth rest of coll, coll when n is 0.
        /// </summary>
        /// <param name="coll">The collection to loop.</param>
        /// <param name="n">Number of Items to drop.</param>
        /// <returns>
        /// Returns the nth rest of coll, coll when n is 0.
        /// </returns>
        public object Invoke(object coll, object n)
        {
            return loop(n, coll);

            object loop(object i, object xs)
            {
                var holder = and(isPos(i), seq(xs));

                if ((bool)truthy(holder))
                    return loop(dec(i), rest(holder));

                return xs;
            }
        }
    }
}
