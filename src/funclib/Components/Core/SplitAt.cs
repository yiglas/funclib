﻿using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Collections.Vector"/> of [<see cref="Take.Invoke(object, object)"/>, <see cref="Drop.Invoke(object, object)"/>].
    /// </summary>
    public class SplitAt :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="Collections.Vector"/> of [<see cref="Take.Invoke(object, object)"/>, <see cref="Drop.Invoke(object, object)"/>].
        /// </summary>
        /// <param name="n">An <see cref="int"/> of the items split collection at.</param>
        /// <param name="coll">A collection being split.</param>
        /// <returns>
        /// Returns a <see cref="Collections.Vector"/> of [<see cref="Take.Invoke(object, object)"/>, <see cref="Drop.Invoke(object, object)"/>].
        /// </returns>
        public object Invoke(object n, object coll) => funclib.Core.Vector(funclib.Core.Take(n, coll), funclib.Core.Drop(n, coll));
    }
}
