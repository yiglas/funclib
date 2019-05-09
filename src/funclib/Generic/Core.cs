using System.Collections.Generic;
using System.Linq.Expressions;
using funclib.Collections.Generic;
using funclib.Components.Core.Generic;

namespace funclib.Generic
{
    public static class Core
    {

        public static string Tess(Expression ex, string test)
        {
            return "test";
        }

        public static string Testing(string s)
        {
            return "map";
        }

        public static string Tte()
        {
            return Tess(Testing, "hello");
        }


        // map(Plus, new [] {1, 2, 3})
        public static string Run<T>(LambdaExpression ex, IEnumerable<T> ints)
        {

        }

        public static int Inc(int x) => x + 1;

        public static void Testing()
        {
            var x = Run(Inc, new[] { 1, 2, 3 });
        }


        public static IFunction and() => new And();
        public static IFunction and<T>() => new And<T>();
        // public static IFunction<T, T> and<T>() => new And<T>();
        // public static IFunctionParams<T, T, T> andP<T>() => new And<T>();


        public static bool And() => (and() as IFunction<bool>).Invoke();
        public static T And<T>(T x) => (and<T>() as IFunction<T, T>).Invoke(x);
        public static T And<T>(T x, params T[] next) => (and<T>() as IFunctionParams<T, T, T>).Invoke(x, next);

        public static void Test<T>(System.Func<T, T> a, T b)
        {
            var x = a(b);
        }

        public static void Test2()
        {
            int b = 0;

            Test(And, b);
        }


        public static bool Falsy<T>(T source) => new Falsy<T>().Invoke(source);
        public static bool Truthy<T>(T source) => new Truthy<T>().Invoke(source);

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

        public static bool Falsy<T>(T source) => new Falsy<T>().Invoke(source);

        public static IFunction Falsy => new Falsy<T>
    }
}
