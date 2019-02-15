using funclib.Collections.Internal;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Collections.Internal.ITransientSet"/> of the same concrete type that
    /// does not contain funclib.Core.Key(s).
    /// </summary>
    public class Disjǃ :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="funclib.Collections.Internal.ITransientSet"/> of the same concrete type that
        /// does not contain funclib.Core.Key(s).
        /// </summary>
        /// <param name="set">Object that implements the <see cref="funclib.Collections.Internal.ITransientSet"/> interface.</param>
        /// <returns>
        /// Returns the set object.
        /// </returns>
        public object Invoke(object set) => set;
        /// <summary>
        /// Returns a <see cref="funclib.Collections.Internal.ITransientSet"/> of the same concrete type that
        /// does not contain funclib.Core.Key(s).
        /// </summary>
        /// <param name="set">Object that implements the <see cref="funclib.Collections.Internal.ITransientSet"/> interface.</param>
        /// <param name="key">Object to remove from the set.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Collections.Internal.ITransientSet"/> without the key.
        /// </returns>
        public object Invoke(object set, object key) => ((ITransientSet)set).Disjoin(key);
        /// <summary>
        /// Returns a <see cref="funclib.Collections.Internal.ITransientSet"/> of the same concrete type that
        /// does not contain funclib.Core.Key(s).
        /// </summary>
        /// <param name="set">Object that implements the <see cref="funclib.Collections.Internal.ITransientSet"/> interface.</param>
        /// <param name="key">Object to remove from the set.</param>
        /// <param name="ks">An array of other object to remove from the set.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Collections.Internal.ITransientSet"/> without all of the items.
        /// </returns>
        public object Invoke(object set, object key, params object[] ks)
        {
            var ret = ((ITransientSet)set).Disjoin(key);
            if (ks != null && ks.Length > 0)
            {
                var n = funclib.Core.Next(ks);
                if (funclib.Core.T(n))
                    return Invoke(ret, funclib.Core.First(ks), (object[])funclib.Core.ToArray(n));

                return Invoke(ret, funclib.Core.First(ks));
            }

            return ret;
        }
    }
}
