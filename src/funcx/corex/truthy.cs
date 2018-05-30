namespace FunctionalLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns true if object is bool and true or object is not null.
        /// </summary>
        /// <param name="source">The <see cref="object"/> checking to is an object.</param>
        /// <returns>
        /// true if object is bool and true or not null, otherwise false.
        /// </returns>
        public static bool truthy(object source) => !falsy(source);
    }
}
