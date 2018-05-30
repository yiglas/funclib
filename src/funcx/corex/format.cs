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
        /// Formats a string using <see cref="string.Format(string, object[])"/>.
        /// </summary>
        /// <param name="fmt"></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>
        ///  A copy of format in which the format items have been replaced by the string representation
        ///  of the corresponding objects in args.
        /// </returns>
        public static string format(string fmt, params object[] args) => string.Format(fmt, args);
    }
}
