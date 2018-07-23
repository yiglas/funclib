using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

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
            (bool)isSet(coll)
                ? coll
                : coll is IReduce r ? persistentǃ(r.Reduce(new Conjǃ(), new Transient().Invoke(hashSet())))
                : persistentǃ(new Reduce1().Invoke(new Conjǃ(), new Transient().Invoke(hashSet()), coll));
    }
}
