using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="null"/> if coll is empty, otherwise coll
    /// </summary>
    public class NotEmpty :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="null"/> if coll is empty, otherwise coll
        /// </summary>
        /// <param name="coll">Object to test.</param>
        /// <returns>
        /// Returns <see cref="null"/> if coll is empty, otherwise coll
        /// </returns>
        public object Invoke(object coll) => (bool)truthy(seq(coll)) ? coll : null;
    }
}
