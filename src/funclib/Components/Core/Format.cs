using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Formats a string using <see cref="string.Format(string, object[])"/> format syntax.
    /// </summary>
    public class Format :
        IFunctionParams<object, object, object>
    {
        /// <summary>
        /// Formats a string using <see cref="string.Format(string, object[])"/> format syntax.
        /// </summary>
        /// <param name="fmt">The string to be formatted.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>
        /// Returns the formated <see cref="string"/>.
        /// </returns>
        public object Invoke(object fmt, params object[] args) => string.Format(fmt.ToString(), args);
    }
}
