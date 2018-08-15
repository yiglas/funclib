using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Gets the validator function for a <see cref="IRef"/> variable.
    /// </summary>
    public class GetValidator :
        IFunction<object, object>
    {
        /// <summary>
        /// Gets the validator function for a <see cref="IRef"/> variable.
        /// </summary>
        /// <param name="ref">An object that implements the <see cref="IRef"/> interface.</param>
        /// <returns>
        /// Returns a <see cref="IFunction"/> that takes one parameter.
        /// </returns>
        public object Invoke(object @ref) => ((IRef)@ref).GetValidator();
    }
}
