using FunctionalLibrary.Collections;
using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Get :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke(object map, object key) =>
            map == null
                ? null
                : map is IGetValue g ? g.GetValue(key)
                : map is System.Collections.IDictionary d ? d[key]
                : map is ISet s ? s.Get(key)
                : map is ITransientSet t ? t.Get(key)
                : (map is string || map.GetType().IsArray) && Numbers.IsNumber(key) ? GetFromArray(map, key)
                : null;

        public object Invoke(object map, object key, object notFound) =>
            map == null
                ? notFound
                : map is IGetValue g ? g.GetValue(key, notFound)
                : map is System.Collections.IDictionary d ? d.Contains(key) ? d[key] : notFound
                : map is ISet s ? s.Contains(key) ? s.Get(key) : notFound
                : map is ITransientSet t ? t.Contains(key) ? t.Get(key) : notFound
                : (map is string || map.GetType().IsArray) && Numbers.IsNumber(key) ? GetFromArray(map, key, notFound)
                : notFound;

        object GetFromArray(object map, object key)
        {
            int n = Numbers.ConvertToInt(key);
            return n >= 0 && n < (int)new Count().Invoke(map) ? new Nth().Invoke(map, n) : null;
        }

        object GetFromArray(object map, object key, object notFound)
        {
            int n = Numbers.ConvertToInt(key);
            return n >= 0 && n < (int)new Count().Invoke(map) ? new Nth().Invoke(map, n) : notFound;
        }
    }
}
