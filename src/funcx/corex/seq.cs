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
        /// Returns a sequence on the collection. If the collection is empty,
        /// returns null. Sequence also works on strings, native arrays (of reference types) 
        /// and any object that implements IEnumerable. Note that sequence cache values, 
        /// thus sequence should not be used on any IEnumerable who's iterator repeatedly 
        /// returns the same mutable object.
        /// </summary>
        /// <typeparam name="T">Generic type of the enumeration.</typeparam>
        /// <param name="coll">The <see cref="object"/>.</param>
        /// <exception cref="ArgumentException">source can't be converted into an <see cref="IEnumerable"/>.</exception>
        /// <returns>
        /// Return the <see cref="IEnumerable"/> object.
        /// </returns>
        public static IEnumerable<T> seq<T>(IEnumerable<T> coll)
        {
            if (coll == null) return null;

            return inter(coll);

            IEnumerable<T> inter(IEnumerable<T> source)
            {
                foreach (var item in source)
                    yield return item;
            }
        }

        //static IEnumerable<T> seqInternal<T>(IEnumerable<T> source)
        //{
        //    foreach (var item in source)
        //        yield return item;
        //}

        ///// <summary>
        ///// Returns a sequence on the collection. If the collection is empty,
        ///// returns null. Sequence also works on strings, native arrays (of reference types) 
        ///// and any object that implements IEnumerable. Note that sequence cache values, 
        ///// thus sequence should not be used on any IEnumerable who's iterator repeatedly 
        ///// returns the same mutable object.
        ///// </summary>
        ///// <param name="coll">The <see cref="object"/>.</param>
        ///// <exception cref="ArgumentException">source can't be converted into an <see cref="IEnumerable"/>.</exception>
        ///// <returns>
        ///// Return the <see cref="IEnumerable"/> object.
        ///// </returns>
        //public static IEnumerable seq(object coll)
        //{
        //    if (coll == null) return null;

        //    var s = coll as IEnumerable;

        //    if (s == null)
        //        throw new ArgumentException($"Don't know how to create IEnumerable from: {coll.GetType().FullName}");

        //    return seqInternal(s);
        //}

        internal static IEnumerable seqInternal(IEnumerable source)
        {
            foreach (var item in source)
                yield return item;
        }
    }
}
