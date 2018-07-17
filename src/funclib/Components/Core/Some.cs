using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Some :
        IFunction<object, object, object>
    {
        public object Invoke(object pred, object coll)
        {
            var fn = (IFunction<object, object>)pred;
            var s = (ISeq)new Seq().Invoke(coll);
            if ((bool)new Truthy().Invoke(s))
            {
                return new Or().Invoke(
                    new Function<object>(() => fn.Invoke(s.First())),
                    new Function<object>(() => Invoke(pred, s.Next()))
                    );
            }
            return null;
        }
    }
}
