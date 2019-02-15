using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="IMap"/> that consists of the rest of the maps conj-ed onto
    /// the funclib.Core.First(. If a key occurs in more than one map, the mapping(s0 from the latter (left-to-right)
    /// will be combined with the mapping in the result by calling f.Invoke(value-in-result, value-in-latter)
    /// </summary>
    public class MergeWith :
        IFunctionParams<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="IMap"/> that consists of the rest of the maps conj-ed onto
        /// the funclib.Core.First(. If a key occurs in more than one map, the mapping(s0 from the latter (left-to-right)
        /// will be combined with the mapping in the result by calling f.Invoke(value-in-result, value-in-latter)
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="maps">A list of object maps to merge.</param>
        /// <returns>
        /// Returns a <see cref="IMap"/> that consists of the rest of the maps conj-ed onto
        /// the funclib.Core.First(. If a key occurs in more than one map, the mapping(s0 from the latter (left-to-right)
        /// will be combined with the mapping in the result by calling f.Invoke(value-in-result, value-in-latter)
        /// </returns>
        public object Invoke(object f, params object[] maps)
        {
            if (funclib.Core.T(funclib.Core.Some(funclib.Core.identity, maps)))
            {
                return funclib.Core.Reduce1(funclib.Core.Func(merge2), maps);
            }

            return null;

            object mergeEntry(object m, object e)
            {
                var k = funclib.Core.Key(e);
                var v = funclib.Core.Value(e);
                if ((bool)funclib.Core.Contains(m, k))
                {
                    return funclib.Core.Assoc(m, k, funclib.Core.Invoke(f, funclib.Core.Get(m, k), v));
                }

                return funclib.Core.Assoc(m, k, v);
            }

            object merge2(object m1, object m2) => funclib.Core.Reduce1(funclib.Core.Func(mergeEntry), funclib.Core.Or(m1, funclib.Core.HashMap()), funclib.Core.Seq(m2));
        }
    }
}
