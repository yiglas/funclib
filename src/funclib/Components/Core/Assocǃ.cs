using funclib.Collections.Internal;
using funclib.Components.Core.Generic;
using System.Linq;

namespace funclib.Components.Core
{
    /// <summary>
    /// When applied to a transient map, adds mapping of funclib.Core.Key(s) to vals(s). 
    /// When applied to a transient vector, sets the val at index. Note -> 
    /// index must be less than or equal to the count of vector. Returns coll.
    /// </summary>
    public class Assocǃ :
        IFunction<object, object, object, object>,
        IFunctionParams<object, object, object, object, object>
    {
        /// <summary>
        /// When applied to a transient map, adds mapping of funclib.Core.Key(s) to vals(s). 
        /// When applied to a transient vector, sets the val at index. Note -> 
        /// index must be less than or equal to the count of vector. Returns coll.
        /// </summary>
        /// <param name="coll">An object that implements the <see cref="ITransientAssociative"/> interface.</param>
        /// <param name="key">The key of the object to associate in the map.</param>
        /// <param name="val">The value of the object to associate in the map.</param>
        /// <returns>
        /// Returns the modified coll object.
        /// </returns>
        public object Invoke(object coll, object key, object val) => ((ITransientAssociative)coll).Assoc(key, val);
        /// <summary>
        /// When applied to a transient map, adds mapping of funclib.Core.Key(s) to vals(s). 
        /// When applied to a transient vector, sets the val at index. Note -> 
        /// index must be less than or equal to the count of vector. Returns coll.
        /// </summary>
        /// <param name="coll">An object that implements the <see cref="ITransientAssociative"/> interface.</param>
        /// <param name="key">The key of the object to associate in the map.</param>
        /// <param name="val">The value of the object to associate in the map.</param>
        /// <param name="kvs">Rest of the key/value pairs to associate in the map with.</param>
        /// <returns>
        /// Returns the modified coll object.
        /// </returns>
        public object Invoke(object coll, object key, object val, params object[] kvs)
        {
            var ret = ((ITransientAssociative)coll).Assoc(key, val);

            if ((bool)funclib.Core.Truthy(kvs))
            {
                if (kvs.Length == 2)
                    return Invoke(ret, kvs[0], kvs[1]);

                return Invoke(ret, kvs[0], kvs[1], kvs.Skip(2).ToArray());
            }

            return ret;
        }
    }
}
