using funclib.Collections;
using funclib.Collections.Internal;
using funclib.Components.Core.Generic;
using System;

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
        /// - <see cref="funclib.Collections.Internal.ITransientSet"/>
        /// - <see cref="funclib.Collections.Internal.ITransientAssociative"/>
        /// - <see cref="ISet"/>
        ///
        /// <code>key</code> needs to be an <see cref="int"/> if coll is either a <see cref="string"/> or <see cref="Array"/>.
        /// </remarks>
        /// <returns>
        /// Returns a <see cref="bool"/>: true if key is present in the collection, otherwise false.
        /// </returns>
        public object Invoke(object coll, object key)
        {
            switch (coll)
            {
                case null:
                    return false;
                case IAssociative a:
                    return a.ContainsKey(key);
                case System.Collections.IDictionary d:
                    return d.Contains(key);
                case ITransientSet ts:
                    return ts.Contains(key);
                case ITransientAssociative ta:
                    return ta.ContainsKey(key);
                case ISet s:
                    return s.Contains(key);
            }

            if (coll is string || coll.GetType().IsArray)
            {
                if (int.TryParse(key.ToString(), out int i))
                    return i >= 0 && i < (int)funclib.Core.Count(coll);

                return false;
            }

            throw new ArgumentException($"{nameof(Contains)} is not supported on type {coll.GetType().Name}");
        }
    }
}
