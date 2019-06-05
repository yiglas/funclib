using funclib.Collections;
using funclib.Collections.Generic;
using System;

namespace funclib.Components.Core.Generic
{
    public class Count :
        IFunction<ICounted, int>,
        IFunction<string, int>
    {
        public int Invoke(ICounted coll)
        {
            return coll?.Count ?? 0;
        }

        public int Invoke(string coll)
        {
            return coll?.Length ?? 0;
        }
    }

    public class Count<T> :
        IFunction<T, int>,
        IFunction<ICollection<T>, int>,
        IFunction<System.Collections.Generic.ICollection<T>, int>
    {
        public int Invoke(ICollection<T> coll)
        {
            if (coll is null) return 0;

            return CountCollection(coll);
        }

        public int Invoke(System.Collections.Generic.ICollection<T> coll)
        {
            return coll?.Count ?? 0;
        }

        public int Invoke(T coll)
        {
            throw new NotImplementedException();
        }

        static int CountCollection(ICollection<T> o)
        {
            var s = funclib.Generic.Core.Seq<T>(o as ISeqable<T>);
            int i = 0;
            for(; s != null; s = s.Next())
            {
                if (s is ICounted)
                {
                    return i + s.Count;
                }

                i++;
            }
            return i;
        }
    }

    public class Count<TKey, TValue> :
        IFunction<IKeyValuePair<TKey, TValue>, int>,
        IFunction<System.Collections.Generic.KeyValuePair<TKey, TValue>, int>
    {
        public int Invoke(IKeyValuePair<TKey, TValue> coll)
        {
            return 2;
        }

        public int Invoke(System.Collections.Generic.KeyValuePair<TKey, TValue> coll)
        {
            return 2;
        }
    }
}
