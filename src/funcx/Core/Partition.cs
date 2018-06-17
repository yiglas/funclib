using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Partition :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>
    {
        public object Invoke(object n, object coll) => Invoke(n, n, coll);
        public object Invoke(object n, object step, object coll) =>
            new LazySeq(() =>
            {
                var s = new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    var p = new DoAll().Invoke(new Take().Invoke(n, s));
                    if (n.Equals(new Count().Invoke(p)))
                        return new Cons().Invoke(p, Invoke(n, step, new NthRest().Invoke(s, step)));
                }
                return null;
            });

        public object Invoke(object n, object step, object pad, object coll) =>
            new LazySeq(() =>
            {
                var s = new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    var p = new DoAll().Invoke(new Take().Invoke(n, s));
                    if (n == new Count().Invoke(p))
                        return new Cons().Invoke(p, Invoke(n, step, pad, new NthRest().Invoke(s, step)));

                    return new List().Invoke(new Take().Invoke(n, new Concat().Invoke(p, pad)));
                }
                return null;
            });
    }
}
