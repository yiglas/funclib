using funclib.Collections;
using funclib.Collections.Internal;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the <see cref="KeyValuePair"/> for the key, or null if key is not present.
    /// </summary>
    public class Find :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns the <see cref="KeyValuePair"/> for the key, or null if key is not present.
        /// </summary>
        /// <param name="map">An object that implements either <see cref="IAssociative"/>, <see cref="System.Collections.IDictionary"/> or <see cref="funclib.Collections.Internal.ITransientAssociative"/> interface.</param>
        /// <param name="key">The key we want to find in the map.</param>
        /// <returns>
        /// Returns the <see cref="KeyValuePair"/> for the key, or null if key is not present.
        /// </returns>
        public object Invoke(object map, object key)
        {
            switch (map)
            {
                case null:
                    return null;

                case IAssociative a:
                    return a.Get(key);

                case System.Collections.IDictionary d:
                    if (d.Contains(key))
                        return KeyValuePair.Create(key, d[key]);

                    return null;

                case ITransientAssociative t:
                    return t.Get(key);
            }

            return null;
        }
    }
}
