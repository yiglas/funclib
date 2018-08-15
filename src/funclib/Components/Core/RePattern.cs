using funclib.Components.Core.Generic;
using System.Text.RegularExpressions;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns an instance of <see cref="Regex"/>, for use, e.g. in <see cref="ReMatcher"/>.
    /// </summary>
    public class RePattern :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns an instance of <see cref="Regex"/>, for use, e.g. in <see cref="ReMatcher"/>.
        /// </summary>
        /// <param name="s">The string to search for a match(s).</param>
        /// <returns>
        /// Returns an instance of <see cref="Regex"/>, for use, e.g. in <see cref="ReMatcher"/>.
        /// </returns>
        public object Invoke(object s) => s is Regex ? s : new Regex((string)s);
    }
}
