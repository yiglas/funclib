using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Components.Core.HashMap"/> with the keys mapped to the corresponding values
    /// </summary>
    public class ZipMap :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.HashMap"/> with the keys mapped to the corresponding values
        /// </summary>
        /// <param name="keys">A <see cref="Seq"/> collection for keys.</param>
        /// <param name="vals">A <see cref="Seq"/> collection for values.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.HashMap"/> with the keys mapped to the corresponding values
        /// </returns>
        public object Invoke(object keys, object vals)
        {
            return loop(funclib.Core.HashMap(), funclib.Core.Seq(keys), funclib.Core.Seq(vals));

            object loop(object map, object ks, object vs)
            {
                if (funclib.Core.T(funclib.Core.And(ks, vs)))
                {
                    return loop(funclib.Core.Assoc(map, funclib.Core.First(ks), funclib.Core.First(vs)), funclib.Core.Next(ks), funclib.Core.Next(vs));
                }

                return map;
            }
        }
    }
}
