using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the nth next of colls. <see cref="Seq"/> is called when n is zero.
    /// </summary>
    public class NthNext :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns the nth next of colls. <see cref="Seq"/> is called when n is zero.
        /// </summary>
        /// <param name="coll">The collection to loop.</param>
        /// <param name="n">Number of Items to drop.</param>
        /// <returns>
        /// Returns the nth next of colls. <see cref="Seq"/> is called when n is zero.
        /// </returns>
        public object Invoke(object coll, object n)
        {
            var xs = new Seq().Invoke(coll);
            if ((bool)new Truthy().Invoke(and(xs, new IsPos().Invoke(n))))
                return Invoke(new Next().Invoke(xs), new Dec().Invoke(n));

            return xs;
        }
    }
}
