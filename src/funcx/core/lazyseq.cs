namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        public static IEnumerable<TResult> lazyseq<TResult>(Func<IEnumerable<TResult>> fn)
        {
            if (fn == null) yield break;

            IEnumerable<TResult> result = fn();

            while (result != null)
            {
                foreach (var item in result)
                    yield return item;

                result = fn();
            }
        }



        //{
        //    var localFn = fn;
        //    TResult sv = default;
        //    IEnumerable<TResult> s = null;

        //    sval();
        //    if (sv != null)
        //    {
        //        var ls = sv;
        //        sv = default;
        //        while (ls is IEnumerable<TResult>)
        //            s = sval();
        //    }

        //    return s;

        //    IEnumerable<TResult> sval()
        //    {
        //        if (localFn != null)
        //        {
        //            sv = localFn();
        //            localFn = null;
        //        }
        //        if (sv != null)
        //            yield return sv;
        //    }
        //}
    }
}
