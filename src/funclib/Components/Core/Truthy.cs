using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if source is a logical true. i.e.:
    /// source is not null or if source is boolean true.
    /// </summary>
    public class Truthy :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if source is a logical true. i.e.:
        /// source is not null or if source is boolean true.
        /// </summary>
        /// <param name="source">Object to test.</param>
        /// <returns>
        /// Returns true if source is a logical true. i.e.:
        /// source is not null or if source is boolean true.
        /// </returns>
        public object Invoke(object source) => !funclib.Core.F(source);
    }
}
