using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMap"/> conj-ed onto
    /// the first. If a key occurs in more than one map, the mapping from the latter (left-to-right)
    /// will be mapping in the result.
    /// </summary>
    public class Merge :
        IFunctionParams<object, object>
    {
        /// <summary>
        /// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMap"/> conj-ed onto
        /// the first. If a key occurs in more than one map, the mapping from the latter (left-to-right)
        /// will be mapping in the result.
        /// </summary>
        /// <param name="maps">List of <see cref="IMap"/>s to merge together.</param>
        /// <returns>
        /// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMap"/> conj-ed onto
        /// the first. If a key occurs in more than one map, the mapping from the latter (left-to-right)
        /// will be mapping in the result.
        /// </returns>
        public object Invoke(params object[] maps)
        {
            if ((bool)truthy(some(funclib.core.Identity, maps)))
            {
                return reduce1(func((object _1, object _2) => conj(or(_1, hashMap()), _2)), maps);
            }

            return null;
        }
    }
}
