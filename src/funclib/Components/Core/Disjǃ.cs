using funclib.Collections.Internal;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="ITransientSet"/> of the same concrete type that
    /// does not contain key(s).
    /// </summary>
    public class Disjǃ :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="ITransientSet"/> of the same concrete type that
        /// does not contain key(s).
        /// </summary>
        /// <param name="set">Object that implements the <see cref="ITransientSet"/> interface.</param>
        /// <returns>
        /// Returns the set object.
        /// </returns>
        public object Invoke(object set) => set;
        /// <summary>
        /// Returns a <see cref="ITransientSet"/> of the same concrete type that
        /// does not contain key(s).
        /// </summary>
        /// <param name="set">Object that implements the <see cref="ITransientSet"/> interface.</param>
        /// <param name="key">Object to remove from the set.</param>
        /// <returns>
        /// Returns a <see cref="ITransientSet"/> without the key.
        /// </returns>
        public object Invoke(object set, object key) => ((ITransientSet)set).Disjoin(key);
        /// <summary>
        /// Returns a <see cref="ITransientSet"/> of the same concrete type that
        /// does not contain key(s).
        /// </summary>
        /// <param name="set">Object that implements the <see cref="ITransientSet"/> interface.</param>
        /// <param name="key">Object to remove from the set.</param>
        /// <param name="ks">An array of other object to remove from the set.</param>
        /// <returns>
        /// Returns a <see cref="ITransientSet"/> without all of the items.
        /// </returns>
        public object Invoke(object set, object key, params object[] ks)
        {
            var ret = ((ITransientSet)set).Disjoin(key);
            if (ks != null && ks.Length > 0)
            {
                var next = new Next().Invoke(ks);
                if ((bool)new Truthy().Invoke(next))
                    return Invoke(ret, new First().Invoke(ks), (object[])new ToArray().Invoke(next));

                return Invoke(ret, new First().Invoke(ks));
            }

            return ret;
        }
    }
}
