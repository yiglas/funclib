using FunctionalLibrary.Collections;
using System;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Take :
        IFunction<object, object, object>
    {
        public object Invoke(object n, object coll) =>
            new LazySeq(new Function<object>(() =>
            {
                if ((bool)new IsPos().Invoke(n))
                {
                    var s = (ISeq)new Seq().Invoke(coll);
                    if ((bool)new Truthy().Invoke(s))
                        return new Cons().Invoke(s.First(), Invoke(new Dec().Invoke(n), new Rest().Invoke(s)));
                }

                return null;
            }));
    }
}
