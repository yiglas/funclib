using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

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
        /// <param name="map">An object that implements either <see cref="IAssociative"/>, <see cref="System.Collections.IDictionary"/> or <see cref="ITransientAssociative"/> interface.</param>
        /// <param name="keyseq">An object containing the keys, that can be <see cref="Seq"/>ed over, </param>
        /// <returns>
        /// Returns a <see cref="Collections.HashMap"/> containing only those entries in map who's key is in keys.
        /// </returns>
        public object Invoke(object map, object keyseq)
        {
            return loop(hashMap(), seq(keyseq));

            object loop(object ret, object keys)
            {
                if ((bool)truthy(keys))
                {
                    var entry = find(map, first(keys));
                    return loop((bool)truthy(entry) ? conj(ret, entry) : ret, next(keys));
                }

                return ret;
            }
        }
    }
}
