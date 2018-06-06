using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Next:
        IFunction<object, ISeq>
    {
        public ISeq Invoke(object coll)
        {
            var enumerate = coll as ISeq ?? (ISeq)new Core.Seq().Invoke(coll);
            if (enumerate == null)
                return null;
            return enumerate.Next();
        }
    }
}
