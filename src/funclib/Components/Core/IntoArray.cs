using funclib.Collections;
using funclib.Components.Core.Generic;
using System;

namespace funclib.Components.Core
{
    public class IntoArray :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object aseq) => Invoke(funclib.Core.Class(funclib.Core.First(aseq)) ?? typeof(object), aseq);
        public object Invoke(object type, object aseq)
        {
            var t = (Type)type;
            var seq = (ISeq)aseq;
            var ret = Array.CreateInstance(t, length(seq));
            for (int i = 0; seq != null; ++i, seq = seq.Next())
                ret.SetValue(Convert.ChangeType(seq.First(), t), i);

            return ret;

            int length(ISeq list)
            {
                    int i = 0;
                    for (var c = list; c != null; c = c.Next())
                        i++;
                    return i;
            }

        }
    }
}
