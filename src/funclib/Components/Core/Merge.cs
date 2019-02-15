using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMap"/> conj-ed onto
    /// the funclib.Core.First(. If a key occurs in more than one map, the mapping from the latter (left-to-right)
    /// will be mapping in the result.
    /// </summary>
    public class Merge :
        IFunctionParams<object, object>
    {
        /// <summary>
        /// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMap"/> conj-ed onto
        /// the funclib.Core.First(. If a key occurs in more than one map, the mapping from the latter (left-to-right)
        /// will be mapping in the result.
        /// </summary>
        /// <param name="maps">List of <see cref="IMap"/>s to merge together.</param>
        /// <returns>
        /// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMap"/> conj-ed onto
        /// the funclib.Core.First(. If a key occurs in more than one map, the mapping from the latter (left-to-right)
        /// will be mapping in the result.
        /// </returns>
        public object Invoke(params object[] maps)
        {
            if (funclib.Core.T(funclib.Core.Some(funclib.Core.identity, maps)))
            {
                return funclib.Core.Reduce1(funclib.Core.Func((_1, _2) => funclib.Core.Conj(funclib.Core.Or(_1, funclib.Core.HashMap()), _2)), maps);
            }

            return null;
        }
    }
}
