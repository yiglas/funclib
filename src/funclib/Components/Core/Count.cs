using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the number of items in the collection. Passing null as coll returns 0.
    /// </summary>
    public class Count :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the number of items in the collection. Passing null as coll returns 0.
        /// </summary>
        /// <param name="coll">Object to count the number of items exists in the collection.</param>
        /// <remarks>
        /// <code>coll</code> can be:
        /// - <see cref="ICounted"/>
        /// - <see cref="ICollection"/>
        /// - <see cref="string"/>
        /// - <see cref="System.Collections.ICollection"/>
        /// - <see cref="System.Collections.IDictionary"/>
        /// - <see cref="System.Collections.DictionaryEntry"/>
        /// - <see cref="KeyValuePair"/>
        /// - <see cref="Array"/>
        /// </remarks>
        /// <returns>
        /// Returns an <see cref="int"/> of the number of items in the collection.
        /// </returns>
        public object Invoke(object coll) =>
            coll is ICounted c
                ? c.Count
                : CountFrom(Ret(coll, coll == null));

        int CountFrom(object coll) =>
            coll == null
                ? 0
                : coll is ICollection ? CountCollection(coll)
                : coll is string s ? s.Length
                : coll is System.Collections.ICollection c ? c.Count
                : coll is System.Collections.IDictionary d ? d.Count
                : coll is System.Collections.DictionaryEntry || coll is KeyValuePair ? 2
                : coll is Array a ? a.GetLength(0)
                : throw new InvalidOperationException($"Count not supported on this type: {coll.GetType().FullName}");

        int CountCollection(object o)
        {
            var s = (ISeq)new Seq().Invoke(o);
            o = null;
            int i = 0;
            for(; s != null; s = s.Next())
            {
                if (s is ICounted)
                    return i + s.Count;
                i++;
            }
            return i;
        }

        public static object Ret(object ret, object nullable) => ret;
    }
}
