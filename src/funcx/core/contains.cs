namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        ///// <summary>
        ///// Returns true if key is present in the given collection, otherwise return false.
        ///// </summary>
        ///// <typeparam name="T">The type of objects to enumerate.</typeparam>
        ///// <param name="coll">Collection to check.</param>
        ///// <param name="key">The key to locate in the <see cref="IEnumerable{T}"/> collection.</param>
        ///// <returns>
        ///// true if key is present in the collection, otherwise false.
        ///// </returns>
        ///// 



        /// <summary>
        /// Returns true if key is present in the given collection, otherwise return false.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="coll">The <see cref="IDictionary{TKey, TValue}"/> to check.</param>
        /// <param name="key">The key to locate in the <see cref="IDictionary{TKey, TValue}"/>.</param>
        /// <returns>
        /// true if key is present in the collection, otherwise false.
        /// </returns>
        public static bool contains<TKey, TValue>(IDictionary<TKey, TValue> coll, TKey key) =>
            coll == null
                ? false
                : coll.ContainsKey(key);

        /// <summary>
        /// Returns true if key is present in the given collection, otherwise return false.
        /// </summary>
        /// <param name="coll">The <see cref="IDictionary"/> to check.</param>
        /// <param name="key">The key to locate in the <see cref="object"/>.</param>
        /// <returns>
        /// true if key is present in the collection, otherwise false.
        /// </returns>
        public static bool contains(IDictionary coll, object key) =>
            coll == null
                ? false
                : coll.Contains(key);

        /// <summary>
        /// Returns true if the number key is within the range of indexes.
        /// </summary>
        /// <param name="coll">The <see cref="string"/> to check.</param>
        /// <param name="key">The index to check.</param>
        /// <returns>
        /// true if index is within the range of indexes, otherwise false.
        /// </returns>
        public static bool contains(string coll, int key) =>
            coll == null || key < 0
                ? false
                : key < coll.Length;

        /// <summary>
        /// Returns true if the number key is within the range of indexes.
        /// </summary>
        /// <param name="coll">The <see cref="ICollection"/> to check.</param>
        /// <param name="key">The index to check.</param>
        /// <returns>
        /// true if index is within the range of indexes, otherwise false.
        /// </returns>
        public static bool contains(ICollection coll, int key) =>
            coll == null || key < 0
                ? false
                : key < coll.Count;

    }
}
