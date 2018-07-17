using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Next :
        IFunction<object, object>
    {
        public object Invoke(object coll)
        {
            var seq = coll as ISeq ?? (ISeq)new Instances.Seq().Invoke(coll);
            if (seq == null)
                return null;
            return seq.Next();
        }
    }
}
