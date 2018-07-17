using System;
using System.Text;

namespace funclib.Components.Core
{
    public class NthRest :
        IFunction<object, object, object>
    {
        public object Invoke(object coll, object n)
        {
            return loop(n, coll);

            object loop(object i, object xs)
            {
                var holder = new And().Invoke(new IsPos().Invoke(i), new Seq().Invoke(xs));

                if ((bool)new Truthy().Invoke(holder))
                    return loop(new Dec().Invoke(i), new Rest().Invoke(holder));

                return xs;
            }
        }
    }
}
