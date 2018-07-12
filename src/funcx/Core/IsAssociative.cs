using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if coll implements <see cref="IAssociative"/> interface, otherwise <see cref="false"/>.
    /// </summary>
    public class IsAssociative :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if coll implements <see cref="IAssociative"/> interface, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="coll">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if coll implements <see cref="IAssociative"/> interface, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object coll) => new IsInstance().Invoke(typeof(IAssociative), coll);
    }
}
