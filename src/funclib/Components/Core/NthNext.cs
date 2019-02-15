using funclib.Components.Core.Generic;

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
            var xs = funclib.Core.Seq(coll);
            if (funclib.Core.T(funclib.Core.And(xs, funclib.Core.IsPos(n))))
                return Invoke(funclib.Core.Next(xs), funclib.Core.Dec(n));

            return xs;
        }
    }
}
