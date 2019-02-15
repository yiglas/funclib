using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Associates a value n a nested associative structure, where ks is a
    /// sequence of keys and v is the new value. Returns a new nested structure.
    /// If any levels do not exists, a new <see cref="Collections.HashMap"/>
    /// will be created.
    /// </summary>
    public class AssocIn :
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Associates a value n a nested associative structure, where ks is a
        /// sequence of keys and v is the new value. Returns a new nested structure.
        /// If any levels do not exists, a new <see cref="Collections.HashMap"/>
        /// will be created.
        /// </summary>
        /// <param name="m">Object that implements the <see cref="IAssociative"/> interface.</param>
        /// <param name="ks">A sequence of keys to find the key/value pair to update.</param>
        /// <param name="v">A new value for the last key to update with.</param>
        /// <returns>
        /// A new nested associative with the value replaced.
        /// </returns>
        public object Invoke(object m, object ks, object v)
        {
            var k = funclib.Core.First(ks);
            ks = funclib.Core.Next(ks);

            if (funclib.Core.T(ks))
                return funclib.Core.Assoc(m, k, Invoke(funclib.Core.Get(m, k), ks, v));

            return funclib.Core.Assoc(m, k, v);
        }
    }
}
