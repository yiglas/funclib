using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class Contains :
        IFunction<IDictionary, object, bool>,
        IFunction<string, int, bool>,
        IFunction<ICollection, int, bool>
    {
        public bool Invoke(IDictionary coll, object key) =>
            coll == null
                ? false
                : coll.Contains(key);

        public bool Invoke(string coll, int key) =>
            coll == null || key < 0
                ? false
                : key < coll.Length;

        public bool Invoke(ICollection coll, int key) =>
            coll == null || key < 0
                ? false
                : key < coll.Count;
    }
}
