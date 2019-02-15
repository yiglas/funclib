using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns null if coll is empty, otherwise coll
    /// </summary>
    public class NotEmpty :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns null if coll is empty, otherwise coll
        /// </summary>
        /// <param name="coll">Object to test.</param>
        /// <returns>
        /// Returns null if coll is empty, otherwise coll
        /// </returns>
        public object Invoke(object coll) => funclib.Core.T(funclib.Core.Seq(coll)) ? coll : null;
    }
}
