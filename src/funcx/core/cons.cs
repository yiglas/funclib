namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
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
                //var activator = Activator.CreateInstance(typeof(List<T>), typeof(IEnumerable<T>));
                //var coll = (IList<T>)activator(seq);

                coll.Insert(0, x);

                return coll;
            }
        }
    }
}
