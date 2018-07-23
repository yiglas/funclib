using funclib.Collections;
using System;
using System.Linq;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Conj[oin]. Returns a new collection with the x 'added'. If 
    /// coll is null, returns a new <see cref="Collections.List"/> with 
    /// x as its first item. The addition may happen at different places
    /// depending on the concrete type of the collection.
    /// </summary>
    public class Conj :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Conj[oin]. Returns a new collection with the x 'added'. If 
        /// coll is null, returns a new <see cref="Collections.List"/> with 
        /// x as its first item. The addition may happen at different places
        /// depending on the concrete type of the collection.
        /// </summary>
        /// <returns>
        /// Returns an <see cref="Collections.Vector.EMPTY"/>.
        /// </returns>
        public object Invoke() => Collections.Vector.EMPTY;
        /// <summary>
        /// Conj[oin]. Returns a new collection with the x 'added'. If 
        /// coll is null, returns a new <see cref="Collections.List"/> with 
        /// x as its first item. The addition may happen at different places
        /// depending on the concrete type of the collection.
        /// </summary>
        /// <param name="coll">Object that implements the <see cref="ICollection"/> interface.</param>
        /// <returns>
        /// Returns the coll object.
        /// </returns>
        public object Invoke(object coll) => coll;
        /// <summary>
        /// Conj[oin]. Returns a new collection with the x 'added'. If 
        /// coll is null, returns a new <see cref="Collections.List"/> with 
        /// x as its first item. The addition may happen at different places
        /// depending on the concrete type of the collection.
        /// </summary>
        /// <param name="coll">Object that implements the <see cref="ICollection"/> interface.</param>
        /// <param name="x">Object to add to the collection.</param>
        /// <returns>
        /// If coll is null returns a new <see cref="Collections.List"/>, otherwise returns 
        /// a new collection with the same concrete type as coll with x <see cref="ICollection.Cons(object)"/>
        /// onto the list.
        /// </returns>
        public object Invoke(object coll, object x) =>
            coll == null
                ? new Collections.List(x)
                : ((ICollection)coll).Cons(x);

        /// <summary>
        /// Conj[oin]. Returns a new collection with the x 'added'. If 
        /// coll is null, returns a new <see cref="Collections.List"/> with 
        /// x as its first item. The addition may happen at different places
        /// depending on the concrete type of the collection.
        /// </summary>
        /// <param name="coll">Object that implements the <see cref="ICollection"/> interface.</param>
        /// <param name="x">Object to add to the collection.</param>
        /// <param name="xs">Array of other objects to add to the collection.</param>
        /// <returns>
        /// Returns a new collection with the same concrete type of coll but with the 
        /// add objects.
        /// </returns>
        public object Invoke(object coll, object x, params object[] xs)
        {
            if (xs != null && xs.Length > 0)
            {
                var n = next(xs);
                if ((bool)truthy(n))
                    return Invoke(Invoke(coll, x), first(xs), (object[])toArray(n));

                return Invoke(Invoke(coll, x), first(xs));
            }
            else
                return Invoke(coll, x);
        }
    }
}
