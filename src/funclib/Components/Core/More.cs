using funclib.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    public class More :
        IFunction<object, object>
    {
        public object Invoke(object coll)
        {
            var enumerate = coll as ISeq ?? (ISeq)new Instances.Seq().Invoke(coll);
            if (enumerate == null)
                return Collections.List.EMPTY;
            return enumerate.Next();
        }
    }
}
