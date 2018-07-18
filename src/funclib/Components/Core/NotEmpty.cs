using System;
using System.Text;

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
        public object Invoke(object coll) =>
            (bool)new Truthy().Invoke(new Seq().Invoke(coll))
                ? coll
                : null;
    }
}
