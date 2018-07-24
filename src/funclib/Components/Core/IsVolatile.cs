using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is of type <see cref="Volatile"/>, otherwise <see cref="false"/>.
    /// </summary>
    public class IsVolatile :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is of type <see cref="Volatile"/>, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is of type <see cref="Volatile"/>, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x) => x is Volatileǃ;
    }
}
