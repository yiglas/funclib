using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections
{
    public class SortedMap
        : Map
    {
        //readonly IComparer _comp;
        //readonly 


        internal SortedMap(object a, object b) { }

        public override int Count => throw new NotImplementedException();

        public override IMap Assoc(object key, object val) => throw new NotImplementedException();
        public override bool ContainsKey(object key) => throw new NotImplementedException();
        public override ICollection Empty() => throw new NotImplementedException();
        public override IEnumerative Enumerate() => throw new NotImplementedException();
        public override KeyValuePair<object, object>? Get(object key) => throw new NotImplementedException();
        public override IEnumerator GetKeyEnumerator() => throw new NotImplementedException();
        public override object GetValue(object key) => throw new NotImplementedException();
        public override object GetValue(object key, object notFound) => throw new NotImplementedException();
        public override IEnumerator GetValueEnumerator() => throw new NotImplementedException();
        public override ITransientCollection ToTransient() => throw new NotImplementedException();
        public override IMap Without(object key) => throw new NotImplementedException();
    }
}
