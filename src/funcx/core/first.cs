using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class First :
        IFunction<object, object>
    {
        public object Invoke(object coll)
        {
            var enumerate = coll as ISeq ?? new Core.Seq().Invoke(coll);
            if (enumerate == null)
                return null;
            return enumerate.First();
        }
    }
}
