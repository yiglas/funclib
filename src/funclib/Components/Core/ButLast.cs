using funclib.Collections;
using funclib.Components.Core.Generic;

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
        public object Invoke(object coll) => anonymous(funclib.Core.Vector(), coll);

        static object anonymous(object ret, object s)
        {
            var n = funclib.Core.Next(s);
            if (funclib.Core.T(n))
                return anonymous(funclib.Core.Conj(ret, funclib.Core.First(s)), n);
            return funclib.Core.Seq(ret);
        }
    }
}
