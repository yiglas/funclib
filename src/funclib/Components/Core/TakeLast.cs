using funclib.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    public class TakeLast :
        IFunction<object, object, object>
    {
        public object Invoke(object n, object coll)
        {
            return loop((ISeq)new Seq().Invoke(n), (ISeq)new Seq().Invoke(new Drop().Invoke(n, coll)));

            object loop(ISeq s, ISeq lead)
            {
                if ((bool)new Truthy().Invoke(lead))
                    return loop(s.Next(), lead.Next());

                return s;
            }
        }
    }
}
