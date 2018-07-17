using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Transduce :
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>
    {
        public object Invoke(object xform, object f, object coll) => Invoke(xform, f, ((IFunction<object>)f).Invoke(), coll);
        public object Invoke(object xform, object f, object init, object coll)
        {
            var xf = ((IFunction<object, object>)xform).Invoke(f);
            object ret;

            if (coll is IReduce r)
                ret = r.Reduce((IFunction)f, init);
            else
                ret = new Reduce().Invoke(f, init);

            return ((IFunction<object, object>)f).Invoke(ret);
        }
    }
}
