using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Return a random element of the <see cref="Collections.ISequential"/> collection.
    /// </summary>
    public class RandNth :
        IFunction<object, object>
    {
        /// <summary>
        /// Return a random element of the <see cref="Collections.ISequential"/> collection.
        /// </summary>
        /// <param name="coll">Collection to search for index.</param>
        /// <returns>
        /// Return a random element of the <see cref="Collections.ISequential"/> collection.
        /// </returns>
        public object Invoke(object coll) => new Nth().Invoke(coll, new RandInt().Invoke(count(coll)));
    }
}
