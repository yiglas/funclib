using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Collections.HashSet"/> of the distinct elements of coll.
    /// </summary>
    public class Set :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="Collections.HashSet"/> of the distinct elements of coll.
        /// </summary>
        /// <param name="coll">Any collection that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="Collections.HashSet"/> of the distinct elements of coll.
        /// </returns>
        public object Invoke(object coll) =>
            (bool)funclib.Core.IsSet(coll)
                ? coll
                : coll is IReduce r ? funclib.Core.Persistentǃ(r.Reduce(funclib.Core.conjǃ, funclib.Core.Transient(funclib.Core.HashSet())))
                : funclib.Core.Persistentǃ(funclib.Core.Reduce1(funclib.Core.conjǃ, funclib.Core.Transient(funclib.Core.HashSet()), coll));
    }
}
