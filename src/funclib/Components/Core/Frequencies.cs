using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

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
            persistentǃ(
                new Reduce().Invoke(
                    new Function<object, object, object>((counts, x) =>
                        assocǃ(counts, x, inc(get(counts, x, 0)))),
                    new Transient().Invoke(hashMap()), coll));
    }
}
