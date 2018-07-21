using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Seq"/> of all but the last item. In linear time.
    /// </summary>
    public class ButLast :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="Seq"/> of all but the last item. In linear time.
        /// </summary>
        /// <param name="coll">List of times to process.</param>
        /// <returns>
        /// Returns a <see cref="ISeq"/> of all items except for the last item.
        /// </returns>
        public object Invoke(object coll)
        {
            return loop(Collections.Vector.EMPTY, coll);
            
            object loop(object ret, object s)
            {
                var n = new Next().Invoke(s);
                if ((bool)new Truthy().Invoke(n))
                    return loop(conj(ret, new First().Invoke(s)), n);
                return new Seq().Invoke(ret);
            }
        }
    }
}
