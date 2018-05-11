using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace funcx.Core
{
    public class Dissoc<TKey, TValue> :
        IFunctionParams<IDictionary<TKey, TValue>, TKey, IDictionary<TKey, TValue>>
    {
        public IDictionary<TKey, TValue> Invoke(IDictionary<TKey, TValue> map, params TKey[] keys)
        {
            if (map == null) return null;

            var remove = keys.ToList();

            return map
                .Where((KeyValuePair<TKey, TValue> x) => !remove.Contains(x.Key))
                .ToDictionary((KeyValuePair<TKey, TValue> x) => x.Key, (KeyValuePair<TKey, TValue> x) => x.Value);
        }
    }
}
