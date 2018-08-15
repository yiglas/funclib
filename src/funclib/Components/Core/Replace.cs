using funclib.Components.Core.Generic;
using System;

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
        public object Invoke(object smap) => funclib.Core.Map(funclib.Core.Func(Transducer(smap)));
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
            if ((bool)funclib.Core.IsVector(coll))
            {
                return funclib.Core.Reduce1(funclib.Core.Func(ReduceInnerInvoke), coll, funclib.Core.Range(funclib.Core.Count(coll)));
            }

            return funclib.Core.Map(funclib.Core.Func(Transducer(smap)), coll);

            object ReduceInnerInvoke(object v, object i)
            {
                var e = funclib.Core.Find(smap, funclib.Core.Nth(v, i));
                if ((bool)funclib.Core.Truthy(e))
                {
                    return funclib.Core.Assoc(v, i, funclib.Core.Value(e));
                }

                return v;
            }
        }

        Func<object, object> Transducer(object smap) =>
            (object item) =>
            {
                var e = funclib.Core.Find(smap, item);
                if ((bool)funclib.Core.Truthy(e))
                {
                    return funclib.Core.Value(e);
                }

                return item;
            };
    }
}
