using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Count :
        IFunction<object, int>
    {
        public int Invoke(object coll) =>
            !(coll is ValueType) && coll == null
                ? 0
                : coll is string s ? s.Length
                : coll is Array a ? a.GetLength(0)
                : coll is IDictionary d ? d.Count
                : coll is ICollection c ? c.Count
                : coll is DictionaryEntry ? 2
                : coll.GetType().Name == "KeyValuePair`2" ? 2
                : coll is IEnumerable e ? enumerableCount(e)
                : throw new InvalidOperationException($"Count not supported on this type: {coll.GetType().FullName}");

        int enumerableCount(IEnumerable e)
        {
            int i = 0;

            foreach (var item in e)
                i++;

            return i;
        }
    }
}
