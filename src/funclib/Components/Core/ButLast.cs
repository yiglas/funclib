using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

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
        public object Invoke(object coll) => anonymous(vector(), coll);

        static object anonymous(object ret, object s)
        {
            var n = next(s);
            if ((bool)truthy(n))
                return anonymous(conj(ret, first(s)), n);
            return seq(ret);
        }
    }
}
