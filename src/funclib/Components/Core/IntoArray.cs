using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class IntoArray :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object aseq) => Invoke((aseq as ISeq)?.First()?.GetType() ?? typeof(object), aseq);
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
