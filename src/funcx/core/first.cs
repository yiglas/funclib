using System;
using System.Collections.Generic;
using System.Text;
using f = funcx.Collections;

namespace funcx.Core
{
    public class First<T> :
        IFunction<IEnumerable<T>, T>
    {
        public T Invoke(IEnumerable<T> coll)
        {
            if (coll == null)
                return default;

            //if (coll is f.ICollection c)
            //    return (T)c.First();

            foreach (var item in coll)
                return item;

            return default;
        }
    }

    public class First<TKey, TValue> :
        IFunction<KeyValuePair<TKey, TValue>, TKey>
    {
        public TKey Invoke(KeyValuePair<TKey, TValue> coll) => coll.Key;
    }
}
