using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace funcx.Core
{
    public class Assoc<TKey, TValue> :
        IFunction<IDictionary<TKey, TValue>, (TKey key, TValue value), IDictionary<TKey, TValue>>,
        IFunctionParams<IDictionary<TKey, TValue>, (TKey key, TValue value), IDictionary<TKey, TValue>>
    {
        public IDictionary<TKey, TValue> Invoke(IDictionary<TKey, TValue> map, (TKey key, TValue value) keyval) =>
            Invoke(map, new(TKey key, TValue value)[] { keyval });

        public IDictionary<TKey, TValue> Invoke(IDictionary<TKey, TValue> map, params (TKey key, TValue value)[] keyvals)
        {
            if (map == null)
                return keyvals.ToDictionary(x => x.key, x => x.value);
            else
            {
                var dict = Activator.CreateInstance(map.GetType(), map) as IDictionary<TKey, TValue>;

                for (int i = 0; i < keyvals.Length; i++)
                {
                    var (key, value) = keyvals[i];

                    if (dict.ContainsKey(key))
                    {
                        dict[key] = value;
                    }
                    else
                    {
                        dict.Add(key, value);
                    }
                }

                return dict;
            }
        }
    }
}
