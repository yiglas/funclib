using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
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
        /// <returns></returns>
        public object Invoke(object coll)
        {
            return loop(Collections.Vector.EMPTY, coll);
            
            object loop(object ret, object s)
            {
                var n = new Next().Invoke(s);
                if ((bool)new Truthy().Invoke(n))
                    return loop(new Conj().Invoke(ret, new First().Invoke(s)), n);
                return new Seq().Invoke(ret);
            }
        }
    }
}
