using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns true if coll implements <see cref="ISequential"/> interface, otherwise false.
    /// </summary>
    public class IsSequential :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if coll implements <see cref="ISequential"/> interface, otherwise false.
        /// </summary>
        /// <param name="coll">An object to test against.</param>
        /// <returns>
        /// Returns true if coll implements <see cref="ISequential"/> interface, otherwise false.
        /// </returns>
        public object Invoke(object coll) => new IsInstance().Invoke(typeof(ISequential), coll);
    }
}
