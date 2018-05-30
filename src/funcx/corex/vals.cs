namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Gets an <see cref="ICollection{T}"/> containing the values of the <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="map">The dictionary pulling the values from.</param>
        /// <returns>
        /// Returns an <see cref="ICollection{T}"/> containing the values of the object that implements <see cref="IDictionary{TKey, TValue}"/>.
        /// </returns>
        public static ICollection<TValue> vals<TKey, TValue>(IDictionary<TKey, TValue> map) => map.Values;
    }
}
