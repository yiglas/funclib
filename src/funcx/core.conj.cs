namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Conj[ion] the collection with xs added.  Position of xs being added, depends on the 
        /// concrete implementation.
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

            if (source == null && xs.Any())
                return new List<T>(xs);
            else
            {
                var items = new T[source.Count + xs.Count()];
                Array.Copy(source.ToArray(), 0, items, 0, source.Count);
                Array.Copy(xs, 0, items, source.Count, xs.Length);

                var list = (IList<T>)Activator.CreateInstance(source.GetType(), items);

                return list;
            }
        }
    }
}
