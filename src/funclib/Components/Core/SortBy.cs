using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    public class SortBy :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke(object keyfn, object coll) => Invoke(keyfn, new Compare(), coll);
        public object Invoke(object keyfn, object comp, object coll)
        {
            var fn = (IFunction<object, object>)keyfn;
            var cfn = (IFunction<object, object, object>)comp;

            return new Sort().Invoke(new Function<object, object, object>((x, y) => cfn.Invoke(fn.Invoke(x), fn.Invoke(y))), coll);
        }
    }
}
