namespace FunctionalLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns the value mapped to the key, notFound or null if key is not present.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value</typeparam>
        /// <param name="map">The <see cref="IDictionary{TKey, TValue}"/> getting the value from the key.</param>
        /// <param name="key">Key to find.</param>
        /// <param name="notFound"><i>Optional</i>. Return this value if the source is null or key not present.</param>
        /// <returns>
        /// Returns found key's value, or the notFound value.
        /// </returns>
        public static TValue get<TKey, TValue>(IDictionary<TKey, TValue> map, TKey key, TValue notFound = default)
        {
            if (map == null) return notFound;
            else if (map.ContainsKey(key)) return map[key];
            else return notFound;
        }

        /// <summary>
        /// Returns the value mapped to the key, notFound or null if key is not present.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="map">The <see cref="IList{T}"/> getting the value from the key.</param>
        /// <param name="index">Index to return.</param>
        /// <param name="notFound"><i>Optional</i>. Return this value if the source is null or key not present.</param>
        /// <returns>
        /// Returns found key's value, or the notFound value.
        /// </returns>
        public static T get<T>(IList<T> map, int index, T notFound = default)
        {
            if (map == null) return notFound;
            else if (map.Count > index) return map[index];
            else return notFound;
        }

        ///// <summary>
        ///// Returns the value mapped to the key, notFound or null if key is not present.
        ///// </summary>
        ///// <param name="map">The <see cref="IList"/> getting the value from the key.</param>
        ///// <param name="index">Index to return.</param>
        ///// <param name="notFound"><i>Optional</i>. Return this value if the source is null or key not present.</param>
        ///// <returns>
        ///// Returns found key's value, or the notFound value.
        ///// </returns>
        //public static object get(IList map, int index, object notFound = null)
        //{
        //    if (map == null) return notFound;
        //    else if (map.Count > index) return map[index];
        //    else return notFound;
        //}
    }
}
