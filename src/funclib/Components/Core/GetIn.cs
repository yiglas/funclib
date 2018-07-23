using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the value in a nested associative structure, where ks
    /// is a sequence of keys. Returns null if the key is not present,
    /// otherwise notFound value if supplied.
    /// </summary>
    public class GetIn :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Returns the value in a nested associative structure, where ks
        /// is a sequence of keys. Returns null if the key is not present,
        /// otherwise notFound value if supplied.
        /// </summary>
        /// <param name="m">Object to pull the final key from.</param>
        /// <param name="ks">Sequence of keys.</param>
        /// <returns>
        /// Returns the key found otherwise null.
        /// </returns>
        public object Invoke(object m, object ks) => reduce1(new Get(), m, ks);
        /// <summary>
        /// Returns the value in a nested associative structure, where ks
        /// is a sequence of keys. Returns null if the key is not present,
        /// otherwise notFound value if supplied.
        /// </summary>
        /// <param name="m">Object to pull the final key from.</param>
        /// <param name="ks">Sequence of keys.</param>
        /// <param name="notFound">Object to return if key is not found.</param>
        /// <returns>
        /// Returns the key found otherwise notFound.
        /// </returns>
        public object Invoke(object m, object ks, object notFound) =>
            loop(new object(), m, (ISeq)seq(ks), notFound);

        object loop(object sentinel, object m, ISeq ks, object notFound)
        {
            if ((bool)truthy(ks))
            {
                m = get(m, ks.First(), sentinel);
                if ((bool)isIdentical(m, sentinel))
                    return notFound;

                return loop(sentinel, m, ks.Next(), notFound);
            }

            return m;
        }
    }
}
