using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Generates a new <see cref="System.Guid"/> object.
    /// </summary>
    public class UUID :
        IFunction<object>
    {
        /// <summary>
        /// Generates a new <see cref="System.Guid"/> object.
        /// </summary>
        /// <returns>
        /// Returns a new <see cref="System.Guid"/> object.
        /// </returns>
        public object Invoke() => System.Guid.NewGuid();
    }
}
