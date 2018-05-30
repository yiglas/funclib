using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Seq :
        IFunction<object, ISeq>
    {
        public ISeq Invoke(object coll)
        {
            if (coll is ASeq e) return e;
            if (coll is Collections.LazySeq le) return le.Seq();
            return From(coll);
        }

        ISeq From(object coll)
        {
            if (coll == null) return null;
            if (coll.GetType().IsArray) throw new NotImplementedException(); // TODO: implement
            if (coll is string s) throw new NotImplementedException(); // TODO: implement
            if (coll is System.Collections.IEnumerable e) throw new NotImplementedException(); // TODO: implement

            throw new ArgumentException($"Do not know how to create {nameof(ISeq)} from {coll.GetType().Name}");
        }
    }
}
