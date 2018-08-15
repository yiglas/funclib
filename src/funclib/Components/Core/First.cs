using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the funclib.Core.First( time in the collection. Calls <see cref="Seq"/> on the collection.
    /// If coll is null, return null.
    /// </summary>
    public class First :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the funclib.Core.First( time in the collection. Calls <see cref="Seq"/> on the collection.
        /// If coll is null, return null.
        /// </summary>
        /// <param name="coll">An object that is <see cref="Seq"/>able.</param>
        /// <returns>
        /// Returns the funclib.Core.First( time in the collection. Calls <see cref="Seq"/> on the collection.
        /// If coll is null, return null.
        /// </returns>
        public object Invoke(object coll)
        {
            var enumerate = coll as ISeq ?? (ISeq)funclib.Core.Seq(coll);
            if (enumerate is null)
                return null;
            return enumerate.First();
        }
    }
}
