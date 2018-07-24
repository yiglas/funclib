using funclib.Collections;
using funclib.Collections.Internal;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="ISeq"/> on the collection. If the collection is empty
    /// returns null. Passing null as the collection, returns null. <see cref="Seq"/>
    /// works on <see cref="string"/>s, <see cref="Array"/>s or any object that implements
    /// the <see cref="System.Collections.IEnumerable"/> interface. Note: that <see cref="Seq"/>
    /// caches values, thus <see cref="Seq"/> should not be used on any enumerable repeatedly
    /// returns the same mutable object.
    /// </summary>
    public class Seq :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="ISeq"/> on the collection. If the collection is empty
        /// returns null. Passing null as the collection, returns null. <see cref="Seq"/>
        /// works on <see cref="string"/>s, <see cref="Array"/>s or any object that implements
        /// the <see cref="System.Collections.IEnumerable"/> interface. Note: that <see cref="Seq"/>
        /// caches values, thus <see cref="Seq"/> should not be used on any enumerable repeatedly
        /// returns the same mutable object.
        /// </summary>
        /// <param name="coll">The collection to <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="ISeq"/> on the collection. If the collection is empty
        /// returns null. Passing null as the collection, returns null. <see cref="Seq"/>
        /// works on <see cref="string"/>s, <see cref="Array"/>s or any object that implements
        /// the <see cref="System.Collections.IEnumerable"/> interface. Note: that <see cref="Seq"/>
        /// caches values, thus <see cref="Seq"/> should not be used on any enumerable repeatedly
        /// returns the same mutable object.
        /// </returns>
        public object Invoke(object coll) => 
            coll is ASeq seq 
                ? seq
                : coll is LazySeq ls ? ls.Seq()
                : coll is null ? null
                : coll is ISeqable seqable ? seqable.Seq()
                : coll.GetType().IsArray ? ArraySeq.Create((object[])coll)
                : coll is string s ? StringSeq.Create(s)
                : coll is System.Collections.IEnumerable ie ? EnumeratorSeq.Create(ie.GetEnumerator())
                : throw new ArgumentException($"Do not know how to create {nameof(ISeq)} from {coll.GetType().Name}");
    }
}
