using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is a <see cref="IMap"/>, otherwise <see cref="false"/>.
    /// </summary>
    public class IsMap :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is a <see cref="IMap"/>, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is a <see cref="IMap"/>, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x) => isInstance(typeof(IMap), x);
    }
}
