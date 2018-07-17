using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Reductions :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke(object f, object coll) =>
            new LazySeq(() =>
            {
                var s = (ISeq)new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    return Invoke(f, s.First(), new Rest().Invoke(s));
                }

                return new List().Invoke(((IFunction<object>)f).Invoke());
            }); 

        public object Invoke(object f, object init, object coll)
        {
            if (init is Reduced r)
                return new List().Invoke(r.Deref());

            return new Cons().Invoke(init, new LazySeq(() =>
            {
                var s = (ISeq)new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                    return Invoke(f, ((IFunction<object, object, object>)f).Invoke(init, s.First()), new Rest().Invoke(s));

                return null;
            }));
        }
    }
}
