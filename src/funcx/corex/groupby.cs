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
        /// Returns a map of the elements of coll keys by the result of f on each element. The value
        /// of each key will be a <see cref="IList{T}"/> of the corresponding elements, in order they 
        /// appear in coll.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="f">The function to key the coll.</param>
        /// <param name="coll">The items to be group by.</param>
        /// <returns>
        /// Returns a <see cref="IDictionary{TKey, TValue}"/> with the items group by.
        /// </returns>
        public static IDictionary<TKey, IList<TValue>> groupby<TKey, TValue>(Func<TValue, TKey> f, IEnumerable<TValue> coll)
        {
            return reduce(fn, new Dictionary<TKey, List<TValue>>() as IDictionary<TKey, IList<TValue>>, coll);

            IDictionary<TKey, IList<TValue>> fn(IDictionary<TKey, IList<TValue>> ret, TValue x)
            {
                var k = f(x);
                return assocT(ret, (k, conj(get(ret, k, new List<TValue>()), x)));
            }
        }
    }
}
