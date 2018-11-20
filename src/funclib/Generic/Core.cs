using funclib.Collections.Generic;
using funclib.Components.Core.Generic;

namespace funclib.Generic
{
    public static class Core
    {
        public static ISeq<T> Seq<T>(ISeq<T> coll) => new Seq<T>().Invoke(coll);
        public static ISeq<T> Seq<T>(ASeq<T> coll) => new Seq<T>().Invoke(coll);
        public static ISeq<T> Seq<T>(ISeqable<T> coll) => new Seq<T>().Invoke(coll);
        public static ISeq<T> Seq<T>(T[] coll) => new Seq<T>().Invoke(coll);
        public static ISeq<T> Seq<T>(System.Collections.Generic.IEnumerable<T> coll) => new Seq<T>().Invoke(coll);
        public static ISeq<T> Seq<T>(string coll) => new Seq<T>().Invoke(coll);

        public static T First<T>(ASeq<T> coll) => new First<T>().Invoke(coll);
        public static T First<T>(ISeqable<T> coll) => new First<T>().Invoke(coll);
        public static T First<T>(T[] coll) => new First<T>().Invoke(coll);
        public static T First<T>(System.Collections.Generic.IEnumerable<T> coll) => new First<T>().Invoke(coll);
        public static char First(string coll) => new First<char>().Invoke(coll);
        public static ISeq<T> Next<T>(ASeq<T> coll) => new Next<T>().Invoke(coll);
        public static ISeq<T> Next<T>(ISeqable<T> coll) => new Next<T>().Invoke(coll);
        public static ISeq<T> Next<T>(T[] coll) => new Next<T>().Invoke(coll);
        public static ISeq<T> Next<T>(System.Collections.Generic.IEnumerable<T> coll) => new Next<T>().Invoke(coll);
        public static ISeq<char> Next(string coll) => new Next<char>().Invoke(coll);

        public static bool IsEqualTo<T>(T a, T b) => new IsEqualTo<T>().Invoke(a, b);

        public static bool IsNull<T>(T x) => new IsNull<T>().Invoke(x);

        public static int Count<T>(T coll) => new Count<T>().Invoke(coll);

    }
}
