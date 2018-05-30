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
        /// Returns true if x is logical false, false otherwise.
        /// </summary>
        /// <param name="x">The <see cref="object"/>.</param>
        /// <returns>
        /// true if source is logically false, otherwise true.
        /// </returns>
        public static bool not(object x) => !truthy(x);
    }
}
