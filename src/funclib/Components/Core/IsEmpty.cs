using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if coll has no items. Same as Not(Seq(coll)).
    /// </summary>
    public class IsEmpty :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if coll has no items. Same as Not(Seq(coll)).
        /// </summary>
        /// <param name="coll">Object to test.</param>
        /// <returns>
        /// Returns true if coll has no items. Same as Not(Seq(coll)).
        /// </returns>
        public object Invoke(object coll) => funclib.Core.Not(funclib.Core.Seq(coll));
    }
}
