using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a possible empty <see cref="Seq"/> of the items after the first.
    /// </summary>
    public class Rest :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a possible empty <see cref="Seq"/> of the items after the first.
        /// </summary>
        /// <param name="coll">An object to return items after the first.</param>
        /// <returns>
        /// Returns a possible empty <see cref="Seq"/> of the items after the first.
        /// </returns>
        public object Invoke(object coll)
        {
            var enumerate = coll as ISeq ?? (ISeq)seq(coll);
            if (enumerate == null)
                return null;
            return enumerate.More();
        }
    }
}
