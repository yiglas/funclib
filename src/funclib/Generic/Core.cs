using funclib.Collections.Generic;
using funclib.Components.Core.Generic;

namespace funclib.Generic
{
    public static class Core
    {
        public static ISeq<T> Seq<T>(object coll) => new Seq<T>().Invoke(coll);

        public static bool IsEqualTo<T>(T a, T b) => new IsEqualTo<T>().Invoke(a, b);

        public static bool IsNull<T>(T x) => new IsNull<T>().Invoke(x);

        public static int Count<T>(T coll) => new Count<T>().Invoke(coll);
    }
}
