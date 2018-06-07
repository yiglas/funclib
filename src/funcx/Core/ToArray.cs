﻿using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ToArray :
        IFunction<object, object>
    {
        public object Invoke(object coll) =>
            coll == null
                ? new object[] { }
                : TryConvertArray(coll, out object[] a) ? a
                : coll is string s ? StringToArray(s)
                : coll.GetType().IsArray ? ObjectToArray(coll)
                : coll is System.Collections.IEnumerable e ? IEnumerableToArray(e)
                : throw new InvalidOperationException($"Unable to convert {coll.GetType()} to object[].");


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
            var ret = new object[(int)new Count().Invoke(seq)];
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