using funcx.Collections;
using System;
using System.Text;

namespace funcx.Core
{
    public class Enumerate :
        IFunction<object, IEnumerative>
    {
        public IEnumerative Invoke(object coll)
        {
            if (coll is Enumerative e) return e;
            if (coll is LazyEnumerative le) return le.Enumerate();
            return From(coll);
        }

        IEnumerative From(object coll)
        {
            if (coll == null) return null;
            if (coll.GetType().IsArray) throw new NotImplementedException(); // TODO: implement
            if (coll is string s) throw new NotImplementedException(); // TODO: implement
            if (coll is System.Collections.IEnumerable e) throw new NotImplementedException(); // TODO: implement

            throw new ArgumentException($"Do not know how to create {nameof(IEnumerative)} from {coll.GetType().Name}");
        }
    }
}
