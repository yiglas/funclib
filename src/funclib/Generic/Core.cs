using funclib.Components.Core.Generic;
using System;

namespace funclib.Generic
{
    public static class Core<T>
    {
        public static IsEqualTo<T> isEqualTo => new IsEqualTo<T>();
        public static Compare<T> compare => new Compare<T>();
        public static And<T> and => new And<T>();
        public static Seq<T> seq => new Seq<T>();
        public static List<T> list => new List<T>();
        public static Cons<T> cons => new Cons<T>();
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
        public static Collections.Generic.ISeq<T> Seq<T>(Collections.Generic.ASeq<T> coll) => Core<T>.seq.Invoke(coll);
        public static Collections.Generic.ISeq<T> Seq<T>(System.Collections.Generic.IEnumerable<T> coll) => Core<T>.seq.Invoke(coll);
        public static Collections.Generic.ISeq<T> Seq<T>(params T[] coll) => Core<T>.seq.Invoke(coll);
        public static Collections.Generic.ISeq<T> Seq<T>(T coll) => Core<T>.seq.Invoke(coll);
        public static Function<T> Func<T>(Func<T> x) => new Function<T>(x);
        public static Collections.Generic.IList<T> List<T>(params T[] items) => Core<T>.list.Invoke(items);
        public static Collections.Generic.ISeq<T> Cons<T>(T x, Collections.Generic.ISeq<T> seq) => Core<T>.cons.Invoke(x, seq);
    }
}
