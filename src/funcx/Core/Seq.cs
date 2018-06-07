using FunctionalLibrary.Collections;
using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Seq :
        IFunction<object, object>
    {
        public object Invoke(object coll) =>
            (int)new Count().Invoke(coll) == 0
                ? null
                : coll is ASeq e ? e
                : coll is Collections.LazySeq le ? le
                : coll == null ? null
                : coll is ISeqable seqable ? seqable.Seq()
                : coll.GetType().IsArray ? ArraySeq.Create((object[])coll)
                : coll is string s ? StringSeq.Create(s)
                : coll is System.Collections.IEnumerable ie ? EnumeratorSeq.Create(ie.GetEnumerator())
                : throw new ArgumentException($"Do not know how to create {nameof(ISeq)} from {coll.GetType().Name}");
    }
}
