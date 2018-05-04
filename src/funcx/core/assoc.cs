namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Assoc[iate]. When applied to a Dictionary, returns a new dictionary of the same type
        /// that contains the mapping of key to value. If key already exists over writes
        /// key with new value.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value</typeparam>
        /// <param name="map">The <see cref="IDictionary{TKey, TValue}"/> associating the key/val to.</param>
        /// <param name="keyval">a single <see cref="ValueTuple{T1, T2}"/>.</param>
        /// <returns>
        /// Returns a new <see cref="IDictionary{TKey, TValue}"/> with the key/value added.
        /// </returns>
        public static IDictionary<TKey, TValue> assoc<TKey, TValue>(IDictionary<TKey, TValue> map, (TKey key, TValue value) keyval) =>
            assoc(map, new (TKey key, TValue value)[] { keyval });

        /// <summary>
        /// Assoc[iate]. When applied to a Dictionary, returns a new dictionary of the same type
        /// that contains the mapping of key to value. If key already exists over writes
        /// key with new value.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value</typeparam>
        /// <param name="map">The <see cref="IDictionary{TKey, TValue}"/> associating the key/val to.</param>
        /// <param name="keyvals">a list of <see cref="ValueTuple{T1, T2}"/>.</param>
        /// <returns>
        /// Returns a new <see cref="IDictionary{TKey, TValue}"/> with the key/value added.
        /// </returns>
        public static IDictionary<TKey, TValue> assoc<TKey, TValue>(IDictionary<TKey, TValue> map, params (TKey key, TValue value)[] keyvals)
        {
            if (map == null)
                return keyvals.ToDictionary(x => x.key, x => x.value);
            else
            {
                var dict = Activator.CreateInstance(map.GetType(), map) as IDictionary<TKey, TValue>;

                for (int i = 0; i < keyvals.Length; i++)
                {
                    var (key, value) = keyvals[i];

                    if (dict.ContainsKey(key))
                    {
                        dict[key] = value;
                    }
                    else
                    {
                        dict.Add(key, value);
                    }
                }
                
                return dict;
            }
        }

        /// <summary>
        /// Adds mapping of key(s) to val(s)
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value</typeparam>
        /// <param name="map">The <see cref="IDictionary{TKey, TValue}"/> associating the key/val to.</param>
        /// <param name="keyval">a list of <see cref="ValueTuple{T1, T2}"/>.</param>
        /// <returns>
        /// Returns a the passed in <see cref="IDictionary{TKey, TValue}"/> with the key/value added.
        /// </returns>
        public static IDictionary<TKey, TValue> assocT<TKey, TValue>(IDictionary<TKey, TValue> map, (TKey key, TValue value) keyval) =>
            assocT(map, new(TKey key, TValue value)[] { keyval });

        /// <summary>
        /// Adds mapping of key(s) to val(s)
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value</typeparam>
        /// <param name="map">The <see cref="IDictionary{TKey, TValue}"/> associating the key/val to.</param>
        /// <param name="keyvals">a list of <see cref="ValueTuple{T1, T2}"/>.</param>
        /// <returns>
        /// Returns a the passed in <see cref="IDictionary{TKey, TValue}"/> with the key/value added.
        /// </returns>
        public static IDictionary<TKey, TValue> assocT<TKey, TValue>(IDictionary<TKey, TValue> map, params (TKey key, TValue value)[] keyvals)
        {
            if (map == null)
                return keyvals.ToDictionary(x => x.key, x => x.value);
            else
            {
                for (int i = 0; i < keyvals.Length; i++)
                {
                    var (key, value) = keyvals[i];

                    if (map.ContainsKey(key))
                    {
                        map[key] = value;
                    }
                    else
                    {
                        map.Add(key, value);
                    }
                }

                return map;
            }
        }
    }
}
