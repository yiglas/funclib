using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Seq"/> of the items after the first. Calls
    /// <see cref="Seq"/> on its argument. If there are no more items, 
    /// returns null.
    /// </summary>
    public class Next :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="Seq"/> of the items after the first. Calls
        /// <see cref="Seq"/> on its argument. If there are no more items, 
        /// returns null.
        /// </summary>
        /// <param name="coll">Should be a <see cref="Collections.ISeqable"/> collection.</param>
        /// <returns>
        /// Returns a <see cref="Seq"/> of the items after the first. Calls
        /// <see cref="Seq"/> on its argument. If there are no more items, 
        /// returns null.
        /// </returns>
        public object Invoke(object coll)
        {
            var seq = coll as ISeq ?? (ISeq)new Seq().Invoke(coll);
            if (seq == null)
                return null;
            return seq.Next();
        }
    }
}
