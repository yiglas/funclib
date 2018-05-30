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
        /// Returns its argument
        /// </summary>
        /// <typeparam name="T">Type of the argument.</typeparam>
        /// <param name="x">Argument</param>
        /// <returns>
        /// Returns its argument
        /// </returns>
        public static T identity<T>(T x) => x;
    }
}
