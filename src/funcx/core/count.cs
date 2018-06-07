using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Count :
        IFunction<object, object>
    {
        public object Invoke(object coll) =>
            !(coll is ValueType) && coll == null
                ? 0
                : coll is string s ? s.Length
                : coll is Array a ? a.GetLength(0)
                : coll is System.Collections.IDictionary d ? d.Count
                : coll is System.Collections.ICollection c ? c.Count
                : coll is System.Collections.DictionaryEntry ? 2
                : coll.GetType().Name == "KeyValuePair`2" ? 2
                : coll is System.Collections.IEnumerable e ? EnumerableCount(e)
                : coll is IChunked chunked ? chunked.Count
                : throw new InvalidOperationException($"Count not supported on this type: {coll.GetType().FullName}");

        int EnumerableCount(System.Collections.IEnumerable e)
        {
            int i = 0;

            foreach (var item in e)
                i++;

            return i;
        }
    }
}
