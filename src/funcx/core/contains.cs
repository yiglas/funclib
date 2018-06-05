using FunctionalLibrary.Collections;
using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Contains :
        IFunction<object, object, object>
    {
        public object Invoke(object coll, object key) =>
            coll == null
                ? false
                : coll is IAssociative a ? a.ContainsKey(key)
                : coll is System.Collections.IDictionary d ? d.Contains(key)
                : coll is String || coll.GetType().IsArray ? int.TryParse(key.ToString(), out int i) ? i >= 0 && i < (int)new Count().Invoke(coll) : false
                : coll is ITransientSet ts ? ts.Contains(key)
                : coll is ITransientAssociative ta ? ta.ContainsKey(key)
                : throw new ArgumentException($"{nameof(Contains)} is not supported on type {coll.GetType().Name}");
    }
}
