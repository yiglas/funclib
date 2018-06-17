using FunctionalLibrary.Collections;
using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Find :
        IFunction<object, object, object>
    {
        public object Invoke(object map, object key) =>
            map == null
                ? null
                : map is IAssociative a ? a.Get(key)
                : map is System.Collections.IDictionary d ? d.Contains(key) ? KeyValuePair.Create(key, d[key]) : null
                : map is ITransientAssociative t ? t.Get(key)
                : null;
    }
}
