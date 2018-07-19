using System;
using System.Text;

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
                var holder = new And().Invoke(new IsPos().Invoke(i), new Seq().Invoke(xs));

                if ((bool)new Truthy().Invoke(holder))
                    return loop(new Dec().Invoke(i), new Rest().Invoke(holder));

                return xs;
            }
        }
    }
}
