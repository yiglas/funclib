using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using funclib.Collections.Generic;
using funclib.Components.Core.Generic;

namespace funclib.Generic
{
    public static class Core<T>
    {
        public static IsEqualTo<T> isEqualTo => new IsEqualTo<T>();
        public static Compare<T> compare => new Compare<T>();
        public static And<T> and => new And<T>();
        public static Seq<T> seq => new Seq<T>();
    }

    public static class Core
    {
        public static And and => new And();

        public static bool IsEqualTo<T>(T x) => Core<T>.isEqualTo.Invoke(x);
        public static bool IsEqualTo<T>(T x, T y) => Core<T>.isEqualTo.Invoke(x, y);
        public static int Compare<T>(T x, T y) => Core<T>.compare.Invoke(x, y);
        public static bool And() => and.Invoke();
        public static T And<T>(T x) => Core<T>.and.Invoke(x);
        public static T And<T>(T x, T y) => Core<T>.and.Invoke(x, y);
        public static ISeq<T> Seq<T>(ASeq<T> coll) => Core<T>.seq.Invoke(coll);
        public static ISeq<T> Seq<T>(ISeq<T> coll) => Core<T>.seq.Invoke(coll);
        public static ISeq<T> Seq<T>(System.Collections.Generic.IEnumerable<T> coll) => Core<T>.seq.Invoke(coll);
        public static ISeq<T> Seq<T>(params T[] coll) => Core<T>.seq.Invoke(coll);
        public static ISeq<T> Seq<T>(T coll) => Core<T>.seq.Invoke(coll);
    }
}
