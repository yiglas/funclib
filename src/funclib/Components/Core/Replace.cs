using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Given a map of replacement pairs and a <see cref="Collections.Vector"/>/collection, returns a
    /// <see cref="Collections.Vector"/>/seq with any elements = a key in smap replaced with the 
    /// corresponding val in smap.
    /// </summary>
    public class Replace :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object smap) => map(func(Transducer(smap)));
        /// <summary>
        /// Given a map of replacement pairs and a <see cref="Collections.Vector"/>/collection, returns a
        /// <see cref="Collections.Vector"/>/seq with any elements = a key in smap replaced with the 
        /// corresponding val in smap.
        /// </summary>
        /// <param name="smap">An object that is either a <see cref="Collections.Vector"/> or an object that can be <see cref="Seq"/>ed over.</param>
        /// <param name="coll">A collection of items.</param>
        /// <returns>
        /// Returns a <see cref="Collections.Vector"/>/seq with any elements = a key in smap replaced with the corresponding val
        /// int smap.
        /// </returns>
        public object Invoke(object smap, object coll)
        {
            if ((bool)isVector(coll))
            {
                return reduce1(func<object, object, object>(ReduceInnerInvoke), coll, range(count(coll)));
            }

            return map(func(Transducer(smap)), coll);

            object ReduceInnerInvoke(object v, object i)
            {
                var e = find(smap, nth(v, i));
                if ((bool)truthy(e))
                {
                    return assoc(v, i, value(e));
                }

                return v;
            }
        }

        Func<object, object> Transducer(object smap) =>
            (object item) =>
            {
                var e = find(smap, item);
                if ((bool)truthy(e))
                {
                    return value(e);
                }

                return item;
            };
    }
}
