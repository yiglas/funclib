using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class Format :
        IFunctionParams<string, object, string>
    {
        public string Invoke(string fmt, params object[] args) => string.Format(fmt, args);
    }
}
