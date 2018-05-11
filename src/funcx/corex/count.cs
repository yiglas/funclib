namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        // TODO: see if is-expression with patterns will be faster
        // TODO: create multiple functions

        /// <summary>
        /// Returns the number of items in the collection. Count on a null will
        /// return 0. Also works on strings, arrays, collections and dictionaries.
        /// </summary>
        /// <param name="coll">The <see cref="object"/> counting.</param>
        /// <returns>
        /// 0 if null or empty otherwise the number of entries in the object.
        /// </returns>
        public static int count<T>(T coll) =>
            !(coll is ValueType) && coll == null
                ? 0
                : coll is string s ? s.Length
                : coll is Array a ? a.GetLength(0)
                : coll is IDictionary d ? d.Count
                : coll is ICollection c ? c.Count
                : coll is DictionaryEntry ? 2
                : coll.GetType().Name == "KeyValuePair`2" ? 2
                : coll is IEnumerable e ? countEnumerable(e)
                : throw new InvalidOperationException($"Count not supported on this type: {coll.GetType().FullName}");


        static int countEnumerable(IEnumerable e)
        {
            int i = 0;

            foreach (var item in e)
                i++;

            return i;
        }
    }
}
