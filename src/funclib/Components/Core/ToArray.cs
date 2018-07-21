using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns an <see cref="object[]"/> containing the contents of coll, which 
    /// can be any collection.
    /// </summary>
    public class ToArray :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns an <see cref="object[]"/> containing the contents of coll, which 
        /// can be any collection.
        /// </summary>
        /// <param name="coll">A collection of items to convert into an object.</param>
        /// <returns>
        /// Returns an <see cref="object[]"/> containing the contents of coll, which 
        /// can be any collection. Returns empty <see cref="object[]"/> if coll is null.
        /// </returns>
        public object Invoke(object coll) =>
            coll == null
                ? new object[] { }
                : TryConvertArray(coll, out object[] a) ? a
                : coll is System.Collections.IEnumerable e ? IEnumerableToArray(e)
                : coll is string s ? StringToArray(s)
                : coll.GetType().IsArray ? ObjectToArray(coll)
                : throw new InvalidCastException($"Unable to cast object of type '{coll.GetType().FullName}' to type 'object[]'.");


        bool TryConvertArray(object coll, out object[] a)
        {
            a = coll as object[];
            return a != null;
        }

        object[] StringToArray(string s)
        {
            var chars = s.ToCharArray();
            var ret = new object[chars.Length];
            for (int i = 0; i < ret.Length; i++)
                ret[i] = chars[i];
            return ret;
        }

        object[] ObjectToArray(object coll)
        {
            var seq = (ISeq)new Seq().Invoke(coll);
            var ret = new object[(int)count(seq)];
            for (int i = 0; i < ret.Length; i++, seq = seq.Next())
                ret[i] = seq.First();
            return ret;
        }

        object[] IEnumerableToArray(System.Collections.IEnumerable e)
        {
            var list = new System.Collections.Generic.List<object>();
            foreach (var o in e)
                list.Add(o);
            return list.ToArray();
        }
    }
}
