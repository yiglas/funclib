using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

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
                : coll is IReduce r ? persistentǃ(r.Reduce(funclib.core.Conjǃ, transient(hashSet())))
                : persistentǃ(reduce1(funclib.core.Conjǃ, transient(hashSet()), coll));
    }
}
