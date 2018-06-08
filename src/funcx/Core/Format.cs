using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Format :
        IFunctionParams<object, object, object>
    {
        public object Invoke(object fmt, params object[] args) => string.Format(fmt.ToString(), args);
    }
}
