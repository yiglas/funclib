﻿using funclib.Collections;
using funclib.Components.Core.Generic;
using System;
using System.Linq;

namespace funclib.Components.Core
{
    /// <summary>
    /// Assoc[iate]. When applied to a map, returns a new map of the same (hash/sort) type.
    /// that contains the mapping of funclib.Core.Key(s) to val(s). When applied to a vector, returns
    /// a new vector that contains val at index. Note -> index must be less than or equal to
    /// count of vector.
    /// </summary>
    public class Assoc :
        IFunction<object, object, object, object>,
        IFunctionParams<object, object, object, object, object>
    {
        /// <summary>
        /// Assoc[iate]. When applied to a map, returns a new map of the same (hash/sort) type.
        /// that contains the mapping of funclib.Core.Key(s) to val(s). When applied to a vector, returns
        /// a new vector that contains val at index. Note -> index must be less than or equal to
        /// count of vector.
        /// </summary>
        /// <param name="map">Object that implements the <see cref="IAssociative"/> interface.</param>
        /// <param name="key">The key of the object to associate in the map.</param>
        /// <param name="val">The value of the object to associate in the map.</param>
        /// <returns>
        /// Returns a new map with the same type of the map object.
        /// </returns>
        public object Invoke(object map, object key, object val)
        {
            if (map is null)
                return funclib.Core.ArrayMap(key, val);

            return ((IAssociative)map).Assoc(key, val);
        }

        /// <summary>
        /// Assoc[iate]. When applied to a map, returns a new map of the same (hash/sort) type.
        /// that contains the mapping of funclib.Core.Key(s) to val(s). When applied to a vector, returns
        /// a new vector that contains val at index. Note -> index must be less than or equal to
        /// count of vector.
        /// </summary>
        /// <param name="map">Object that implements the <see cref="IAssociative"/> interface.</param>
        /// <param name="key">The key of the object to associate in the map.</param>
        /// <param name="val">The value of the object to associate in the map.</param>
        /// <param name="kvs">Rest of the key/value pairs to associate in the map with.</param>
        /// <returns>
        /// Returns a new map with the same type of the map object.
        /// </returns>
        public object Invoke(object map, object key, object val, params object[] kvs)
        {
            var ret = Invoke(map, key, val);
            if (kvs.Count() % 2 == 0)
            {
                var n = funclib.Core.NNext(kvs);
                if (n is null)
                    return Invoke(ret, funclib.Core.First(kvs), funclib.Core.Second(kvs));
                else
                    return Invoke(ret, funclib.Core.First(kvs), funclib.Core.Second(kvs), (object[])funclib.Core.ToArray(n));
            }
            else
                throw new ArgumentException($"{nameof(Assoc)} expects an even number of arguments.");
        }
    }
}
