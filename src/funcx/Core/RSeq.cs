using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class RSeq :
        IFunction<object, object>
    {
        public object Invoke(object rev) => ((IReversible)rev).RSeq();
    }
}
