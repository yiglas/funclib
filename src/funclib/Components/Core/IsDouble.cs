using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is a <see cref="double"/>, otherwise <see cref="false"/>.
    /// </summary>
    public class IsDouble :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is a <see cref="double"/>, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is a <see cref="double"/>, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x) => x is double;
    }
}
