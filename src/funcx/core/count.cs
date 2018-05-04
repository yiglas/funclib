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
        public static int count(object coll)
        {
            if (!(coll is ValueType) && coll == null) return 0;
            else if (coll is string) return (coll as string).Length;
            else if (coll is Array) return (coll as Array).GetLength(0);
            else if (coll is IDictionary) return (coll as IDictionary).Count;
            else if (coll is ICollection) return (coll as ICollection).Count;
            else if (coll is DictionaryEntry) return 2;
            else if (coll.GetType().Name == "KeyValuePair`2") return 2;
            else if (coll is IEnumerable)
            {
                int i = 0;
                
                foreach (var item in (coll as IEnumerable))
                    i++;

                return i;
            }

            throw new InvalidOperationException($"Count not supported on this type: {coll.GetType().FullName}");
        }
    }
}
