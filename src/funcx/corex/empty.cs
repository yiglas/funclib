namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
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
                : Activator.CreateInstance(coll.GetType()) as ICollection<T>;
    }
}
