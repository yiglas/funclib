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
        public static IEnumerable<TResult> nthrest<TResult>(IEnumerable<TResult> coll, int n)
        {
            if (coll == null) return null;

            var val = drop(n, coll);

            var list = Activator.CreateInstance(coll.GetType(), val) as IEnumerable<TResult>;

            return list;
        }
    }
}
