using funclib.Collections;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the value at the index. <see cref="Nth"/> throws an exception if index
    /// is out of bounds or unless notFound is supplied. <see cref="Nth"/> works on 
    /// strings, arrays, Regex matcher, lists and O(n) time for sequences.
    /// </summary>
    public class Nth :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Returns the value at the index. <see cref="Nth"/> throws an exception if index
        /// is out of bounds or unless notFound is supplied. <see cref="Nth"/> works on 
        /// strings, arrays, Regex matcher, lists and O(n) time for sequences.
        /// </summary>
        /// <param name="coll">Collection to search for index.</param>
        /// <param name="index">Index to find.</param>
        /// <returns>
        /// Returns the value at the index. <see cref="Nth"/> throws an exception if index
        /// is out of bounds or unless notFound is supplied. <see cref="Nth"/> works on 
        /// strings, arrays, Regex matcher, lists and O(n) time for sequences.
        /// </returns>
        public object Invoke(object coll, object index) =>
            int.TryParse(index.ToString(), out int i)
                ? nth(coll, i)
                : null;

        /// <summary>
        /// Returns the value at the index. <see cref="Nth"/> throws an exception if index
        /// is out of bounds or unless notFound is supplied. <see cref="Nth"/> works on 
        /// strings, arrays, Regex matcher, lists and O(n) time for sequences.
        /// </summary>
        /// <param name="coll">Collection to search for index.</param>
        /// <param name="index">Index to find.</param>
        /// <param name="notFound">Value to return if index is not found.</param>
        /// <returns>
        /// Returns the value at the index. <see cref="Nth"/> throws an exception if index
        /// is out of bounds or unless notFound is supplied. <see cref="Nth"/> works on 
        /// strings, arrays, Regex matcher, lists and O(n) time for sequences.
        /// </returns>
        public object Invoke(object coll, object index, object notFound) =>
            int.TryParse(index.ToString(), out int i)
                ? nth(coll, i, notFound)
                : null;


        object nth(object coll, int index) =>
            coll == null
                ? null
                : coll is string s ? s[index]
                : coll.GetType().IsArray ? nth((Array)coll, index)
                : coll is IVector v ? v[index]
                : coll is IChunked c ? c[index]
                : coll is System.Collections.IList l ? l[index]
                : coll is funclib.ReMatcher re ? re.Group(index)
                : coll is Match m ? m.Groups[index]
                : coll is System.Collections.DictionaryEntry de ? index == 0 ? de.Key : index == 1 ? de.Value : throw new ArgumentOutOfRangeException(nameof(index))
                : coll is KeyValuePair kvp ? index == 0 ? kvp.Key : index == 1 ? kvp.Value : throw new ArgumentOutOfRangeException(nameof(index))
                : coll is ISeq seq ? nth(seq, index)
                : throw new InvalidOperationException($"{nameof(Nth)} no supported on this type: {coll.GetType().FullName}");

        object nth(object coll, int index, object notFound) =>
            coll == null
                ? notFound
                : index < 0 ? notFound
                : coll is string s ? index < s.Length ? s[index] : notFound
                : coll.GetType().IsArray ? nth((Array)coll, index, notFound)
                : coll is IVector v ? v[index, notFound]
                : coll is IChunked c ? c[index, notFound]
                : coll is System.Collections.IList l ? l[index]
                : coll is funclib.ReMatcher re ? re.IsUnrealizedOrFailed ? notFound : index < re.GroupCount() ? re.Group(index) : notFound
                : coll is Match m ? index < m.Groups.Count ? m.Groups[index] : notFound
                : coll is System.Collections.DictionaryEntry de ? index == 0 ? de.Key : index == 1 ? de.Value : notFound
                : coll is KeyValuePair kvp ? index == 0 ? kvp.Key : index == 1 ? kvp.Value : notFound
                : coll is ISeq seq ? nth(seq, index, notFound)
                : notFound;

        object nth(ISeq seq, int index)
        {
            for (int i = 0; i < index && seq != null; ++i, seq = seq.Next())
            {
                if (i == index)
                    return seq.First();
            }
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        object nth(ISeq seq, int index, object notFound)
        {
            for (int i = 0; i < index && seq != null; ++i, seq = seq.Next())
            {
                if (i == index)
                    return seq.First();
            }
            return notFound;
        }

        object nth(Array coll, int index) => coll.GetValue(index);
        object nth(Array coll, int index, object notFound) => index < coll.Length ? coll.GetValue(index) : notFound;

    }
}
