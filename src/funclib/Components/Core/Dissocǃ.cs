using funclib.Components.Core.Generic;
using funclib.Collections;
using funclib.Collections.Internal;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="ITransientMap"/> of the same concrete type that 
    /// doesn't contain the same <see cref="KeyValuePair"/>
    /// </summary>
    public class Dissocǃ :
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="ITransientMap"/> of the same concrete type that 
        /// doesn't contain the same <see cref="KeyValuePair"/>
        /// </summary>
        /// <param name="map">Object that implements the <see cref="ITransientMap"/> interface.</param>
        /// <param name="key">Key for the <see cref="KeyValuePair"/> to remove from the map.</param>
        /// <returns>
        /// Returns a <see cref="ITransientMap"/> collection without the given key.
        /// </returns>
        public object Invoke(object map, object key) => ((ITransientMap)map).Without(key);
        /// <summary>
        /// Returns a <see cref="ITransientMap"/> of the same concrete type that 
        /// doesn't contain the same <see cref="KeyValuePair"/>
        /// </summary>
        /// <param name="map">Object that implements the <see cref="ITransientMap"/> interface.</param>
        /// <param name="key">Key for the <see cref="KeyValuePair"/> to remove from the map.</param>
        /// <param name="ks">An array of keys for the <see cref="KeyValuePair"/> to remove from the map.</param>
        /// <returns>
        /// Returns a <see cref="ITransientMap"/> collection without all the given keys.
        /// </returns>
        public object Invoke(object map, object key, params object[] ks)
        {
            var ret = ((ITransientMap)map).Without(key);

            if (ks != null && ks.Length > 0)
            {
                var n = next(ks);
                if ((bool)truthy(n))
                    return Invoke(ret, first(ks), (object[])toArray(n));

                return Invoke(ret, first(ks));
            }

            return ret;
        }
    }
}
