using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Interleave :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke() => Collections.List.EMPTY;
        public object Invoke(object c1) => new LazySeq(c1);
        public object Invoke(object c1, object c2) =>
            new LazySeq(() =>
            {
                var s1 = new Seq().Invoke(c1);
                var s2 = new Seq().Invoke(c2);
                if ((bool)new Truthy().Invoke(new And().Invoke(s1, s2)))
                {
                    return new Cons().Invoke(new First().Invoke(s1), new Cons().Invoke(new First().Invoke(s2), Invoke(new Rest().Invoke(s1), new Rest().Invoke(s2))));
                }

                return null;
            });
        public object Invoke(object c1, object c2, params object[] colls) =>
            new LazySeq(() =>
            {
                var ss = new Map().Invoke(new Seq(), new Conj().Invoke(colls, c2, c1));
                if ((bool)new IsEvery().Invoke(new Identity(), ss))
                {
                    return new Concat().Invoke(new Map().Invoke(new First(), ss), new Apply().Invoke(new Interleave(), new Map().Invoke(new Rest(), ss)));
                }
                return null;
            });
    }
    //public class Interleave :
    //    IFunction<IEnumerable, IEnumerable<object>>,
    //    IFunction<IEnumerable, IEnumerable, IEnumerable<object>>,
    //    IFunctionParams<IEnumerable, IEnumerable, IEnumerable, IEnumerable<object>>
    //{
    //    public IEnumerable<object> Invoke(IEnumerable c1)
    //    {
    //        if (c1 == null) yield break;

    //        var e1 = c1.GetEnumerator();

    //        while (e1.MoveNext())
    //        {
    //            yield return e1.Current;
    //        }
    //    }

    //    public IEnumerable<object> Invoke(IEnumerable c1, IEnumerable c2)
    //    {
    //        if (c1 == null || c2 == null) yield break;

    //        var e1 = c1.GetEnumerator();
    //        var e2 = c2.GetEnumerator();

    //        while (e1.MoveNext() && e2.MoveNext())
    //        {
    //            yield return e1.Current;
    //            yield return e2.Current;
    //        }
    //    }

    //    public IEnumerable<object> Invoke(IEnumerable c1, IEnumerable c2, params IEnumerable[] colls)
    //    {
    //        throw new NotImplementedException("TODO: implement this function. need to get apply to work");
    //    }
    //}
}
