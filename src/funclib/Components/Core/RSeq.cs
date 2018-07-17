using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class RSeq :
        IFunction<object, object>
    {
        public object Invoke(object rev) => ((IReversible)rev).RSeq();
    }
}
