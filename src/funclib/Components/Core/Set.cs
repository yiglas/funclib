using funclib.Collections;
using System;
using System.Text;

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
            (bool)new IsSet().Invoke(coll)
                ? coll
                : coll is IReduce r ? new Persistentǃ().Invoke(r.Reduce(new Conjǃ(), new Transient().Invoke(new HashSet().Invoke())))
                : new Persistentǃ().Invoke(new Reduce1().Invoke(new Conjǃ(), new Transient().Invoke(new HashSet().Invoke()), coll));
    }
}
