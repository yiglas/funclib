using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace funcx.Core
{
    public class Assoc :
        IFunction<IDictionary, (object key, object value), IDictionary>,
        IFunctionParams<IDictionary, (object key, object value), IDictionary>
    {
        public IDictionary Invoke(IDictionary map, (object key, object value) keyval) =>
            Invoke(map, new(object key, object value)[] { keyval });

        public IDictionary Invoke(IDictionary map, params (object key, object value)[] keyvals)
        {
            if (map == null)
                return keyvals.ToDictionary(x => x.key, x => x.value);
            else
            {
                var dict = Activator.CreateInstance(map.GetType(), map) as IDictionary;

                for (int i = 0; i < keyvals.Length; i++)
                {
                    var (key, value) = keyvals[i];

                    if (dict.Contains(key))
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
    public class AssocT :
        IFunction<IDictionary, (object key, object value), IDictionary>,
        IFunctionParams<IDictionary, (object key, object value), IDictionary>
    {
        public IDictionary Invoke(IDictionary map, (object key, object value) keyval) =>
            Invoke(map, new(object key, object value)[] { keyval });

        public IDictionary Invoke(IDictionary map, params (object key, object value)[] keyvals)
        {
            if (map == null)
                return keyvals.ToDictionary(x => x.key, x => x.value);
            else
            {
                for (int i = 0; i < keyvals.Length; i++)
                {
                    var (key, value) = keyvals[i];

                    if (map.Contains(key))
                    {
                        map[key] = value;
                    }
                    else
                    {
                        map.Add(key, value);
                    }
                }

                return map;
            }
        }
    }
}
