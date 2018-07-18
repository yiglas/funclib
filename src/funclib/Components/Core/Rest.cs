using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Rest :
        IFunction<object, object>
    {
        public object Invoke(object coll)
        {
            var enumerate = coll as ISeq ?? (ISeq)new Seq().Invoke(coll);
            if (enumerate == null)
                return null;
            return enumerate.More();
        }
    }
}
