using funclib.Components.Core.Generic;

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
        public object Invoke(object m, object ks) => funclib.Core.Reduce1(funclib.Core.get, m, ks);
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
            loop(new object(), m, funclib.Core.Seq(ks), notFound);

        static object loop(object sentinel, object m, object ks, object notFound)
        {
            if ((bool)funclib.Core.Truthy(ks))
            {
                m = funclib.Core.Get(m, funclib.Core.First(ks), sentinel);
                if ((bool)funclib.Core.IsIdentical(m, sentinel))
                    return notFound;

                return loop(sentinel, m, funclib.Core.Next(ks), notFound);
            }

            return m;
        }
    }
}
