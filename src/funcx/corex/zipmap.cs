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
        /// Returns a map with the keys mapped to the corresponding vals.
        /// </summary>
        /// <typeparam name="TKey">Generic type of the keys</typeparam>
        /// <typeparam name="TValue">Generic type of the values.</typeparam>
        /// <param name="keys">A list of the keys for the dictionary.</param>
        /// <param name="vals">A list of the values for the dictionary.</param>
        /// <returns>
        /// Returns a <see cref="IDictionary{TKey, TValue}"/> with the keys/values joined together. 
        /// </returns>
        /// <remarks>
        /// 1. If the keys are not unique you can potentially lose data
        /// 2. The dictionary is the length of the shortest enumerable.
        /// </remarks>
        public static IDictionary<TKey, TValue> zipmap<TKey, TValue>(IEnumerable<TKey> keys, IEnumerable<TValue> vals)
        {
            var results = new Dictionary<TKey, TValue>();

            if (keys == null || vals == null) return results;

            using (var e1 = keys.GetEnumerator())
            using (var e2 = vals.GetEnumerator())
                while (e1.MoveNext() && e2.MoveNext())
                    if (!results.ContainsKey(e1.Current))
                        results.Add(e1.Current, e2.Current);

            return results;
        }
    }
}
