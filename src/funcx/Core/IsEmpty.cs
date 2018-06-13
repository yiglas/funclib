using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsEmpty :
        IFunction<object, object>
    {
        public object Invoke(object coll) => new Not().Invoke(new Seq().Invoke(coll));
    }
}
