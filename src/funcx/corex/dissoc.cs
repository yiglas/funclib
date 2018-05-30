namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Dissoc[iate]. Returns a new dictionary of the same type,
        /// that does not contain a mapping for key(s).
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value</typeparam>
        /// <param name="map">The <see cref="IDictionary{TKey, TValue}"/> disassociating the keys from.</param>
        /// <param name="keys">A list of keys to remove from the Dictionary.</param>
        /// <returns>
        /// Returns a new <see cref="IDictionary{TKey, TValue}"/> with the key removed.
        /// </returns>
        public static IDictionary<TKey, TValue> dissoc<TKey, TValue>(IDictionary<TKey, TValue> map, params TKey[] keys)
        {
            if (map == null) return null;

            var remove = keys.ToList();

            return map
                .Where((KeyValuePair<TKey, TValue> x) => !remove.Contains(x.Key))
                .ToDictionary((KeyValuePair<TKey, TValue> x) => x.Key, (KeyValuePair<TKey, TValue> x) => x.Value);
        }
    }
}
