using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

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
            return loop(hashMap(), (ISeq)seq(keys), (ISeq)seq(vals));

            object loop(object map, ISeq ks, ISeq vs)
            {
                if ((bool)truthy(and(ks, vs)))
                {
                    return loop(assoc(map, ks.First(), vs.First()), ks.Next(), vs.Next());
                }

                return map;
            }
        }
    }
}
