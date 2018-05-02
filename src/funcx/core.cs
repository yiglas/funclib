namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class core
    {
        #region inc
        /// <summary>
        /// Increases the number by one greater.
        /// </summary>
        /// <param name="x">The <see cref="long"/> to increase by 1.</param>
        /// <returns>
        /// Returns a number one greater.
        /// </returns>
        public static long inc(long x) => ++x;

        /// <summary>
        /// Increases the number by one greater.
        /// </summary>
        /// <param name="x">The <see cref="int"/> to increase by 1.</param>
        /// <returns>
        /// Returns a number one greater.
        /// </returns>
        public static int inc(int x) => ++x;

        /// <summary>
        /// Increases the number by one greater.
        /// </summary>
        /// <param name="x">The <see cref="double"/> to increase by 1.</param>
        /// <returns>
        /// Returns a number one greater.
        /// </returns>
        public static double inc(double x) => ++x;

        /// <summary>
        /// Increases the number by one greater.
        /// </summary>
        /// <param name="x">The <see cref="float"/> to increase by 1.</param>
        /// <returns>
        /// Returns a number one greater.
        /// </returns>
        public static float inc(float x) => ++x;
        #endregion

        /// <summary>
        /// Conj[ion] the collection with xs added.  Position of xs being added, depends on the 
        /// concret implemntation.
        /// </summary>
        /// <typeparam name="T">The generic type of the collection.</typeparam>
        /// <param name="source">The collection being added to.</param>
        /// <param name="xs">The items being added to the collection.</param>
        /// <returns>
        /// Returns a new collection with xs added to the list.
        /// </returns>
        public static IList<T> conj<T>(IList<T> source = null, params T[] xs)
        {
            if (source == null && !xs.Any()) return new List<T>();

            if (source == null)
                return new List<T>(xs);
            else
            {
                var list = (IList<T>)Activator.CreateInstance(source.GetType(), source);
                foreach (var x in xs)
                    list.Add(x);

                return list;
            }
        }

        /// <summary>
        /// Returns an empty collection of the same category as source, or null.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="coll">The <see cref="ICollection{T}"/>.</param>
        /// <returns>
        /// Returns a new collection.
        /// </returns>
        public static ICollection<T> empty<T>(ICollection<T> coll) =>
            coll == null
                ? null
                : (ICollection<T>)Activator.CreateInstance(coll.GetType());

        /// <summary>
        /// Returns a new <see cref="ICollection{T}"/> where x is the first element an the source is the rest.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="x">The value adding to the beginning of the list</param>
        /// <param name="seq">The <see cref="ICollection{T}"/> object.</param>
        /// <returns>
        /// Returns a new <see cref="ICollection{T}"/>.
        /// </returns>
        public static ICollection<T> cons<T>(T x, ICollection<T> seq)
        {
            if (seq == null) return new List<T>() { x };
            else
            {
                var coll = (List<T>)Activator.CreateInstance(typeof(List<T>), seq);

                coll.Insert(0, x);

                return coll;
            }
        }

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
                var dict = (IDictionary<TKey, TValue>)Activator.CreateInstance(map.GetType(), map);

                foreach (var (key, value) in keyvals)
                    if (dict.ContainsKey(key))
                    {
                        dict[key] = value;
                    }
                    else
                    {
                        dict.Add(key, value);
                    }

                return dict;
            }
        }

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

            return (IDictionary<TKey, TValue>)Activator.CreateInstance(map.GetType(),
                map
                    .Where(x => !remove.Contains(x.Key))
                    .ToDictionary(x => x.Key, x => x.Value));
        }
    }
}
