using funclib.Components.Core.Generic;

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
                var holder = funclib.Core.And(funclib.Core.IsPos(i), funclib.Core.Seq(xs));

                if (funclib.Core.T(holder))
                    return loop(funclib.Core.Dec(i), funclib.Core.Rest(holder));

                return xs;
            }
        }
    }
}
