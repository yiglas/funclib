using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Adds x to the transient collection. and returns coll. The addition may happen 
    /// at different places depending on the concrete type of the collection.
    /// </summary>
    public class Conjǃ :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        /// <summary>
        /// Adds x to the transient collection. and returns coll. The addition may happen 
        /// at different places depending on the concrete type of the collection.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="ITransientCollection"/> for an empty <see cref="Collections.Vector"/>.
        /// </returns>
        public object Invoke() => transient(new Vector().Invoke());
        /// <summary>
        /// Adds x to the transient collection. and returns coll. The addition may happen 
        /// at different places depending on the concrete type of the collection.
        /// </summary>
        /// <param name="coll">Object of the collection to return.</param>
        /// <returns>
        /// Returns the coll object.
        /// </returns>
        public object Invoke(object coll) => coll;
        /// <summary>
        /// Adds x to the transient collection. and returns coll. The addition may happen 
        /// at different places depending on the concrete type of the collection.
        /// </summary>
        /// <param name="coll">Object that implement the <see cref="ITransientCollection"/> interface.</param>
        /// <param name="x"></param>
        /// <returns>
        /// Returns a <see cref="ITransientCollection"/> with the object added.
        /// </returns>
        public object Invoke(object coll, object x) => ((ITransientCollection)coll).Conj(x);
    }
}
