namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static partial class core
    {
        public static IEnumerable<T[]> partition<T>(int n, IEnumerable<T> coll) => partition(n, n, coll);

        public static IEnumerable<T[]> partition<T>(int n, int step, IEnumerable<T> coll) => null;
            //lazyseq(() => whenlet(seq<T>(coll),
            //    s => let(
            //        take(n, s),
            //        p => when(n == count(p),
            //            () => cons(p, partition(n, step, nthrest(s, step)))))));
    }
}
