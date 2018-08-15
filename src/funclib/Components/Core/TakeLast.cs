using funclib.Collections;
using funclib.Components.Core.Generic;

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
        /// <param name="coll">The collection to drop the funclib.Core.First( x items from.</param>
        /// <returns>
        /// Returns a <see cref="ISeq"/> of the last n items in coll. Depending on the 
        /// type of coll may be no better than linear time.
        /// </returns>
        public object Invoke(object n, object coll)
        {
            return loop(funclib.Core.Seq(coll), funclib.Core.Seq(funclib.Core.Drop(n, coll)));

            object loop(object s, object lead)
            {
                if ((bool)funclib.Core.Truthy(lead))
                    return loop(funclib.Core.Next(s), funclib.Core.Next(lead));

                return s;
            }
        }
    }
}
