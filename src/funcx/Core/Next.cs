using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Next :
        IFunction<object, object>
    {
        public object Invoke(object coll)
        {
            var seq = coll as ISeq ?? (ISeq)new Core.Seq().Invoke(coll);
            if (seq == null)
                return null;
            return seq.Next();
        }
    }
}
