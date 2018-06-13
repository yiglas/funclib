using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Drop :
        IFunction<object, object, object>
    {
        public object Invoke(object n, object coll) => new LazySeq(() => step(n, coll));

        object step(object n, object coll)
        {
            var s = new Seq().Invoke(coll);
            if ((bool)new And().Invoke(new IsPos().Invoke(n), s))
            {
                return step(new Dec().Invoke(n), new Rest().Invoke(s));
            }
            return s;
        }
    }
}
