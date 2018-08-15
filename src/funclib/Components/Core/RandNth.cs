using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Return a random element of the <see cref="Collections.ISequential"/> collection.
    /// </summary>
    public class RandNth :
        IFunction<object, object>
    {
        /// <summary>
        /// Return a random element of the <see cref="Collections.ISequential"/> collection.
        /// </summary>
        /// <param name="coll">Collection to search for index.</param>
        /// <returns>
        /// Return a random element of the <see cref="Collections.ISequential"/> collection.
        /// </returns>
        public object Invoke(object coll) => funclib.Core.Nth(coll, funclib.Core.RandInt(funclib.Core.Count(coll)));
    }
}
