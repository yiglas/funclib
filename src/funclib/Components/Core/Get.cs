using funclib.Components.Core.Generic;
using funclib.Collections;
using funclib.Collections.Internal;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the value mapped to the key, notFound or null if key is not present.
    /// </summary>
    public class Get :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Returns the value mapped to the key, notFound or null if key is not present.
        /// </summary>
        /// <param name="map">Object to pull key from.</param>
        /// <param name="key">If object is a map object, key is the key, otherwise key is an integer of the index.</param>
        /// <returns>
        /// Returns the value mapped to the key, notFound or null if key is not present.
        /// </returns>
        public object Invoke(object map, object key) =>
            map is null
                ? null
                : map is IGetValue g ? g.GetValue(key)
                : map is System.Collections.IDictionary d ? d[key]
                : map is ISet s ? s.Get(key)
                : map is ITransientSet t ? t.Get(key)
                : (map is string || map.GetType().IsArray) && Numbers.IsNumber(key) ? GetFromArray(map, key)
                : null;

        /// <summary>
        /// Returns the value mapped to the key, notFound or null if key is not present.
        /// </summary>
        /// <param name="map">Object to pull key from.</param>
        /// <param name="key">If object is a map object, key is the key, otherwise key is an integer of the index.</param>
        /// <param name="notFound">Object that returns if the key is not found.</param>
        /// <returns>
        /// Returns the value mapped to the key, notFound or null if key is not present.
        /// </returns>
        public object Invoke(object map, object key, object notFound) =>
            map is null
                ? notFound
                : map is IGetValue g ? g.GetValue(key, notFound)
                : map is System.Collections.IDictionary d ? d.Contains(key) ? d[key] : notFound
                : map is ISet s ? s.Contains(key) ? s.Get(key) : notFound
                : map is ITransientSet t ? t.Contains(key) ? t.Get(key) : notFound
                : (map is string || map.GetType().IsArray) && Numbers.IsNumber(key) ? GetFromArray(map, key, notFound)
                : notFound;

        static object GetFromArray(object map, object key)
        {
            int n = Numbers.ConvertToInt(key);
            return n >= 0 && n < (int)count(map) ? nth(map, n) : null;
        }

        static object GetFromArray(object map, object key, object notFound)
        {
            int n = Numbers.ConvertToInt(key);
            return n >= 0 && n < (int)count(map) ? nth(map, n) : notFound;
        }
    }
}
