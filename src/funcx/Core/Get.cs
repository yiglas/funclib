using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Get<TKey, TValue> :
        IFunction<IDictionary<TKey, TValue>, TKey, TValue>,
        IFunction<IDictionary<TKey, TValue>, TKey, TValue, TValue>
    {
        public TValue Invoke(IDictionary<TKey, TValue> map, TKey key) => Invoke(map, key, default);

        public TValue Invoke(IDictionary<TKey, TValue> map, TKey key, TValue notFound)
        {
            if (map == null) return notFound;
            else if (map.ContainsKey(key)) return map[key];
            else return notFound;
        }
    }

    public class Get<T> :
        IFunction<IList<T>, int, T>,
        IFunction<IList<T>, int, T, T>
    {
        public T Invoke(IList<T> map, int key) => Invoke(map, key, default);

        public T Invoke(IList<T> map, int key, T notFound)
        {
            if (map == null) return notFound;
            else if (map.Count > key) return map[key];
            else return notFound;
        }
    }
}
