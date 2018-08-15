using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a map from distinct items in coll to the number of times they appear.
    /// </summary>
    public class Frequencies :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="Collections.HashMap"/> from distinct items in coll to the number of times they appear.
        /// </summary>
        /// <param name="coll">An object to run distinct against.</param>
        /// <returns>
        /// Returns a <see cref="Collections.HashMap"/> from distinct items in coll to the number of times they appear.
        /// </returns>
        public object Invoke(object coll) =>
            funclib.Core.Persistentǃ(funclib.Core.Reduce(funclib.Core.Func((counts, x) => funclib.Core.Assocǃ(counts, x, funclib.Core.Inc(funclib.Core.Get(counts, x, 0)))), funclib.Core.Transient(funclib.Core.HashMap()), coll));
    }
}
