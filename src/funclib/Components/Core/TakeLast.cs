using funclib.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="ISeq"/> of the last n items in coll. Depending on the 
    /// type of coll may be no better than linear time.
    /// </summary>
    public class TakeLast :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="ISeq"/> of the last n items in coll. Depending on the 
        /// type of coll may be no better than linear time.
        /// </summary>
        /// <param name="n">An <see cref="int"/> of the items to take from the end of the collection.</param>
        /// <param name="coll">The collection to drop the first x items from.</param>
        /// <returns>
        /// Returns a <see cref="ISeq"/> of the last n items in coll. Depending on the 
        /// type of coll may be no better than linear time.
        /// </returns>
        public object Invoke(object n, object coll)
        {
            return loop((ISeq)new Seq().Invoke(coll), (ISeq)new Seq().Invoke(new Drop().Invoke(n, coll)));

            object loop(ISeq s, ISeq lead)
            {
                if ((bool)new Truthy().Invoke(lead))
                    return loop(s.Next(), lead.Next());

                return s;
            }
        }
    }
}
