using funclib.Collections;
using funclib.Collections.Internal;
using funclib.Components.Core.Generic;

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
        public object Invoke(object map, object key)
        {
            switch (map)
            {
                case null:
                    return null;
                case IGetValue g:
                    return g.GetValue(key);
                case System.Collections.IDictionary d:
                    return d[key];
                case ISet s:
                    return s.Get(key);
                case ITransientSet t:
                    return t.Get(key);
            }

            if ((map is string || map.GetType().IsArray) && Numbers.IsNumber(key))
                return GetFromArray(map, key);
            
            return null;
        }

        /// <summary>
        /// Returns the value mapped to the key, notFound or null if key is not present.
        /// </summary>
        /// <param name="map">Object to pull key from.</param>
        /// <param name="key">If object is a map object, key is the key, otherwise key is an integer of the index.</param>
        /// <param name="notFound">Object that returns if the key is not found.</param>
        /// <returns>
        /// Returns the value mapped to the key, notFound or null if key is not present.
        /// </returns>
        public object Invoke(object map, object key, object notFound)
        {
            switch (map)
            {
                case null:
                    return notFound;
                case IGetValue g:
                    return g.GetValue(key, notFound);
                case System.Collections.IDictionary d:
                    if (d.Contains(key))
                        return d[key];
                    
                    return notFound;
                case ISet s:
                    if (s.Contains(key))
                        return s.Get(key);
                    
                    return notFound;
                case ITransientSet t:
                    if (t.Contains(key))
                        return t.Get(key);
                    
                    return notFound;
            }

            if ((map is string || map.GetType().IsArray) && Numbers.IsNumber(key))
                return GetFromArray(map, key, notFound);
            
            return notFound;
        }

        static object GetFromArray(object map, object key)
        {
            int n = Numbers.ConvertToInt(key);
            return n >= 0 && n < (int)funclib.Core.Count(map) ? funclib.Core.Nth(map, n) : null;
        }

        static object GetFromArray(object map, object key, object notFound)
        {
            int n = Numbers.ConvertToInt(key);
            return n >= 0 && n < (int)funclib.Core.Count(map) ? funclib.Core.Nth(map, n) : notFound;
        }
    }
}
