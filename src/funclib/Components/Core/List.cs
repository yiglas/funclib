using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Creates a new <see cref="Collections.List"/> containing the times.
    /// </summary>
    public class List :
        IFunctionParams<object, object>
    {
        /// <summary>
        /// Creates a new <see cref="Collections.List"/> containing the times.
        /// </summary>
        /// <param name="items">List of items to add.</param>
        /// <returns>
        /// Returns a new <see cref="Collections.List"/> containing the items.
        /// </returns>
        public object Invoke(params object[] items) => Collections.List.Create(items);
    }
}
