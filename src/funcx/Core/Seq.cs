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
            coll is ASeq seq 
                ? seq.Count == 0 ? null : seq
                : coll is LazySeq ls ? ls.Seq()
                : coll == null ? null
                : coll is ISeqable seqable ? seqable.Seq()
                : coll.GetType().IsArray ? ArraySeq.Create((object[])coll)
                : coll is string s ? StringSeq.Create(s)
                : coll is System.Collections.IEnumerable ie ? EnumeratorSeq.Create(ie.GetEnumerator())
                : throw new ArgumentException($"Do not know how to create {nameof(ISeq)} from {coll.GetType().Name}");
    }
}
