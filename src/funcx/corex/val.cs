namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns the value of the <see cref="KeyValuePair{TKey, TValue}"/> entry.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="e">The <see cref="KeyValuePair{TKey, TValue}"/> object.</param>
        /// <returns>
        /// Returns the value of the <see cref="KeyValuePair{TKey, TValue}"/> entry.
        /// </returns>
        public static TValue val<TKey, TValue>(KeyValuePair<TKey, TValue> e) => e.Value;
    }
}