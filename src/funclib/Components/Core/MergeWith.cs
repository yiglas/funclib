using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMaps"/> conj-ed onto
    /// the first. If a key occurs in more than one map, the mapping(s0 from the latter (left-to-right)
    /// will be combined with the mapping in the result by calling f.Invoke(value-in-result, value-in-latter)
    /// </summary>
    public class MergeWith :
        IFunctionParams<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMaps"/> conj-ed onto
        /// the first. If a key occurs in more than one map, the mapping(s0 from the latter (left-to-right)
        /// will be combined with the mapping in the result by calling f.Invoke(value-in-result, value-in-latter)
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="maps">A list of object maps to merge.</param>
        /// <returns>
        /// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMaps"/> conj-ed onto
        /// the first. If a key occurs in more than one map, the mapping(s0 from the latter (left-to-right)
        /// will be combined with the mapping in the result by calling f.Invoke(value-in-result, value-in-latter)
        /// </returns>
        public object Invoke(object f, params object[] maps)
        {
            if ((bool)truthy(some(funclib.core.Identity, maps)))
            {
                return reduce1(func<object, object, object>(merge2), maps);
            }

            return null;

            object mergeEntry(object m, object e)
            {
                var k = key(e);
                var v = value(e);
                if ((bool)contains(m, k))
                {
                    return assoc(m, k, invoke(f, get(m, k), v));
                }

                return assoc(m, k, v);
            }

            object merge2(object m1, object m2) => reduce1(func<object, object, object>(mergeEntry), or(m1, hashMap()), seq(m2));
        }
    }
}
