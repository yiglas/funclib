using funclib.Collections;
using System;
using System.Linq;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Dissoc[iate]. Returns a new map of the same concrete type,
    /// that does not contain a mapping for the key(s).
    /// </summary>
    public class Dissoc :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Dissoc[iate]. Returns a new map of the same concrete type,
        /// that does not contain a mapping for the key(s).
        /// </summary>
        /// <param name="map">Object that implements the <see cref="IMap"/> interface.</param>
        /// <returns>
        /// Returns the map object.
        /// </returns>
        public object Invoke(object map) => map;
        /// <summary>
        /// Dissoc[iate]. Returns a new map of the same concrete type,
        /// that does not contain a mapping for the key(s).
        /// </summary>
        /// <param name="map">Object that implements the <see cref="IMap"/> interface.</param>
        /// <param name="key">Key to be removed from the map.</param>
        /// <returns>
        /// Returns a new <see cref="IMap"/> collection with out the key.
        /// </returns>
        public object Invoke(object map, object key) => ((IMap)map).Without(key);
        /// <summary>
        /// Dissoc[iate]. Returns a new map of the same concrete type,
        /// that does not contain a mapping for the key(s).
        /// </summary>
        /// <param name="map">Object that implements the <see cref="IMap"/> interface.</param>
        /// <param name="key">Key to be removed from the map.</param>
        /// <param name="ks">An array of other object to remove from the map.</param>
        /// <returns>
        /// Returns null if the map parameter is null, otherwise removes all items from
        /// the <see cref="IMap"/> collection and returns a new <see cref="IMap"/> collection.
        /// </returns>
        public object Invoke(object map, object key, params object[] ks)
        {
            if (map == null) return null;

            var ret = Invoke(map, key);
            if (ks != null && ks.Length > 0)
            {
                var n = next(ks);
                if ((bool)new Truthy().Invoke(n))
                    return Invoke(ret, first(ks), (object[])new ToArray().Invoke(n));

                return Invoke(ret, first(ks));
            }

            return ret;
        }
    }
}
