using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class NthNext :
        IFunction<object, object, object>
    {
        public object Invoke(object coll, object n)
        {
            var xs = new And().Invoke(new Seq().Invoke(coll), new IsPos().Invoke(n));
            if ((bool)new Truthy().Invoke(xs))
                return Invoke(new Next().Invoke(xs), new Dec().Invoke(n));

            return xs;
        }
    }
}
