using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a possible empty <see cref="Seq"/> of the items after the funclib.Core.First(.
    /// </summary>
    public class Rest :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a possible empty <see cref="Seq"/> of the items after the funclib.Core.First(.
        /// </summary>
        /// <param name="coll">An object to return items after the funclib.Core.First(.</param>
        /// <returns>
        /// Returns a possible empty <see cref="Seq"/> of the items after the funclib.Core.First(.
        /// </returns>
        public object Invoke(object coll)
        {
            var enumerate = coll as ISeq ?? (ISeq)funclib.Core.Seq(coll);
            if (enumerate is null)
                return null;
            return enumerate.More();
        }
    }
}
