using funclib.Collections;
using funclib.Collections.Internal;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Collections.HashMap"/> containing only those entries in map who's key is in keys.
    /// </summary>
    public class SelectKeys :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="Collections.HashMap"/> containing only those entries in map who's key is in keys.
        /// </summary>
        /// <param name="map">An object that implements either <see cref="IAssociative"/>, <see cref="System.Collections.IDictionary"/> or <see cref="funclib.Collections.Internal.ITransientAssociative"/> interface.</param>
        /// <param name="keyseq">An object containing the keys, that can be <see cref="Seq"/>ed over, </param>
        /// <returns>
        /// Returns a <see cref="Collections.HashMap"/> containing only those entries in map who's key is in keys.
        /// </returns>
        public object Invoke(object map, object keyseq)
        {
            return loop(funclib.Core.HashMap(), funclib.Core.Seq(keyseq));

            object loop(object ret, object keys)
            {
                if (funclib.Core.T(keys))
                {
                    var entry = funclib.Core.Find(map, funclib.Core.First(keys));
                    return loop(funclib.Core.T(entry) ? funclib.Core.Conj(ret, entry) : ret, funclib.Core.Next(keys));
                }

                return ret;
            }
        }
    }
}
