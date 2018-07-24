using funclib.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Seq"/> of the items after the first. Calls
    /// <see cref="Seq"/> on its argument. If there are no more items, 
    /// returns <see cref="Collections.List.EMPTY"/> collection.
    /// </summary>
    public class More :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="Seq"/> of the items after the first. Calls
        /// <see cref="Seq"/> on its argument. If there are no more items, 
        /// returns <see cref="Collections.List.EMPTY"/> collection.
        /// </summary>
        /// <param name="coll">Should be a <see cref="Collections.ISeqable"/> collection.</param>
        /// <returns>
        /// Returns a <see cref="Seq"/> of the items after the first. Calls
        /// <see cref="Seq"/> on its argument. If there are no more items, 
        /// returns <see cref="Collections.List.EMPTY"/> collection.
        /// </returns>
        public object Invoke(object coll)
        {
            var enumerate = coll as ISeq ?? (ISeq)seq(coll);
            if (enumerate is null)
                return Collections.List.EMPTY;
            return enumerate.Next();
        }
    }
}
