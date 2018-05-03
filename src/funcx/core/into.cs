namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns a new <see cref="ICollection{T}"/> consisting of the to list conjoined with the source.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="to">The <see cref="ICollection{T}"/> object.</param>
        /// <param name="from">Items to conjoin into source.</param>
        /// <returns>
        /// Returns a new <see cref="ICollection{T}"/>.
        /// </returns>
        public static ICollection<T> into<T>(ICollection<T> to, ICollection<T> from)
        {
            if (to == null && from == null) return new List<T>();

            if (to == null && from.Any())
                return new List<T>(from);
            else
            {
                int fromCnt = from?.Count ?? 0;

                var items = new T[to.Count + fromCnt];

                if (from != null)
                    Array.Copy(from.Reverse().ToArray(), 0, items, 0, from.Count);

                Array.Copy(to.ToArray(), 0, items, from?.Count ?? 0, to.Count);

                var list = Activator.CreateInstance(to.GetType(), items) as IList<T>;

                return list;
            }
        }

        /// <summary>
        /// Returns a new <see cref="IDictionary{TKey, TValue}"/> consisting of the to list conjoined with the source.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="to">The <see cref="IDictionary{TKey, TValue}"/> object.</param>
        /// <param name="from">Items to conjoin into source.</param>
        /// <returns>
        /// Returns a new <see cref="IDictionary{TKey, TValue}"/>.
        /// </returns>
        public static IDictionary<TKey, TValue> into<TKey, TValue>(IDictionary<TKey, TValue> to, IDictionary<TKey, TValue> from)
        {
            if (to == null && from == null) return new Dictionary<TKey, TValue>();

            if (to == null && from.Any())
                return new Dictionary<TKey, TValue>(from);
            else
            {
                var items = new Dictionary<TKey, TValue>();

                if (from != null)
                    foreach (var item in from.Reverse())
                        Add(items, item.Key, item.Value);

                foreach (var item in to)
                    Add(items, item.Key, item.Value);

                return items;
            }

            void Add(IDictionary<TKey, TValue> items, TKey key, TValue value)
            {
                if (!items.ContainsKey(key))
                    items.Add(key, value);
            }
        }
    }
}
