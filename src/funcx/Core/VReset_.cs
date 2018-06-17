using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class VReset_ :
        IFunction<object, object, object>
    {
        public object Invoke(object vol, object newVal) => ((Volatile)vol).Reset(newVal);
    }
}
