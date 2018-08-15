using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Seq"/> of the items after the funclib.Core.First(. Calls
    /// <see cref="Seq"/> on its argument. If there are no more items, 
    /// returns null.
    /// </summary>
    public class Next :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="Seq"/> of the items after the funclib.Core.First(. Calls
        /// <see cref="Seq"/> on its argument. If there are no more items, 
        /// returns null.
        /// </summary>
        /// <param name="coll">Should be a <see cref="Collections.ISeqable"/> collection.</param>
        /// <returns>
        /// Returns a <see cref="Seq"/> of the items after the funclib.Core.First(. Calls
        /// <see cref="Seq"/> on its argument. If there are no more items, 
        /// returns null.
        /// </returns>
        public object Invoke(object coll)
        {
            var s = coll as ISeq ?? (ISeq)funclib.Core.Seq(coll);
            if (s is null)
                return null;
            return s.Next();
        }
    }
}
