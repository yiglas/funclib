using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="HashMap"/> with the keys mapped to the corresponding values
    /// </summary>
    public class ZipMap :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="HashMap"/> with the keys mapped to the corresponding values
        /// </summary>
        /// <param name="keys">A <see cref="Seq"/> collection for keys.</param>
        /// <param name="vals">A <see cref="Seq"/> collection for values.</param>
        /// <returns>
        /// Returns a <see cref="HashMap"/> with the keys mapped to the corresponding values
        /// </returns>
        public object Invoke(object keys, object vals)
        {
            return loop(hashMap(), seq(keys), seq(vals));

            object loop(object map, object ks, object vs)
            {
                if ((bool)truthy(and(ks, vs)))
                {
                    return loop(assoc(map, first(ks), first(vs)), next(ks), next(vs));
                }

                return map;
            }
        }
    }
}
