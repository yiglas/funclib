using funclib.Collections;
using funclib.Collections.Internal;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if key is present in the given collection, otherwise false. Note
    /// that for numerically indexed collections like vectors and arrays, this test is the 
    /// number key is within the range of indexes. <see cref="Contains"/> operates constant or 
    /// logarithmic time; it will not perform a linear search for a value.
    /// </summary>
    public class Contains :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns true if key is present in the given collection, otherwise false. Note
        /// that for numerically indexed collections like vectors and arrays, this test is the 
        /// number key is within the range of indexes. <see cref="Contains"/> operates constant or 
        /// logarithmic time; it will not perform a linear search for a value.
        /// </summary>
        /// <param name="coll">Collection to check if key exists.</param>
        /// <param name="key">Object to check if contains in the collection.</param>
        /// <remarks>
        /// <code>coll</code> can be either:
        /// - <see cref="IAssociative"/>,
        /// - <see cref="System.Collections.IDictionary"/>
        /// - <see cref="string"/>
        /// - <see cref="Array"/>
        /// - <see cref="ITransientSet"/>
        /// - <see cref="ITransientAssociative"/>
        /// - <see cref="ISet"/>
        /// 
        /// <code>key</code> needs to be an <see cref="int"/> if coll is either a <see cref="string"/> or <see cref="Array"/>.
        /// </remarks>
        /// <returns>
        /// Returns a <see cref="bool"/>: true if key is present in the collection, otherwise false.
        /// </returns>
        public object Invoke(object coll, object key) =>
            coll is null
                ? false
                : coll is IAssociative a ? a.ContainsKey(key)
                : coll is System.Collections.IDictionary d ? d.Contains(key)
                : coll is string || coll.GetType().IsArray ? int.TryParse(key.ToString(), out int i) ? i >= 0 && i < (int)count(coll) : false
                : coll is ITransientSet ts ? ts.Contains(key)
                : coll is ITransientAssociative ta ? ta.ContainsKey(key)
                : coll is ISet s ? s.Contains(key)
                : throw new ArgumentException($"{nameof(Contains)} is not supported on type {coll.GetType().Name}");
    }
}
