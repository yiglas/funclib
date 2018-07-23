using funclib.Collections;
using System;
using System.Linq;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Disj[oin]. Returns a new set of the same concrete type, that 
    /// does not contain they key(s).
    /// </summary>
    public class Disj :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Disj[oin]. Returns a new set of the same concrete type, that 
        /// does not contain they key(s).
        /// </summary>
        /// <param name="set">Object that implements the <see cref="ISet"/> interface.</param>
        /// <returns>
        /// Returns the set object.
        /// </returns>
        public object Invoke(object set) => set;
        /// <summary>
        /// Disj[oin]. Returns a new set of the same concrete type, that 
        /// does not contain they key(s).
        /// </summary>
        /// <param name="set">Object the implements the <see cref="ISet"/> interface.</param>
        /// <param name="key">Object to remove from the set.</param>
        /// <returns>
        /// Returns a new <see cref="ISet"/> collection without the key.
        /// </returns>
        public object Invoke(object set, object key) => ((ISet)set).Disj(key);
        /// <summary>
        /// Disj[oin]. Returns a new set of the same concrete type, that 
        /// does not contain they key(s).
        /// </summary>
        /// <param name="set">Object the implements the <see cref="ISet"/> interface.</param>
        /// <param name="key">Object to remove from the set.</param>
        /// <param name="ks">An array of other object to remove from the set.</param>
        /// <returns>
        /// Returns null if the set parameter is null, otherwise removes all items from the
        /// <see cref="ISet"/> collection and returns a new <see cref="ISet"/> collection.
        /// </returns>
        public object Invoke(object set, object key, params object[] ks)
        {
            if (set == null) return null;

            var ret = Invoke(set, key);
            if (ks != null && ks.Length > 0)
            {
                var n = next(ks);
                if ((bool)truthy(n))
                    return Invoke(ret, first(ks), (object[])toArray(n));

                return Invoke(ret, first(ks));
            }

            return ret;
        }
    }
}
