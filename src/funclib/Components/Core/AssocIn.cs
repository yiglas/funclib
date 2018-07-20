using System;
using System.Text;
using static funclib.Core;

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
            var k = new First().Invoke(ks);
            ks = new Next().Invoke(ks);

            if ((bool)new Truthy().Invoke(ks))
                return assoc(m, k, Invoke(new Get().Invoke(m, k), ks, v));

            return assoc(m, k, v);
        }
    }
}
