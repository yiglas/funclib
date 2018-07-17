using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    public class ReFind :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object m) => ((FunctionalLibrary.ReMatcher)m).Find() ? new ReGroups().Invoke(m) : null;
        public object Invoke(object re, object s) => Invoke(new ReMatcher().Invoke(re, s));
    }
}
