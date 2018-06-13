using FunctionalLibrary.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class More :
        IFunction<object, object>
    {
        public object Invoke(object coll)
        {
            var enumerate = coll as ISeq ?? (ISeq)new Core.Seq().Invoke(coll);
            if (enumerate == null)
                return Collections.List.EMPTY;
            return enumerate.Next();
        }
    }
}
