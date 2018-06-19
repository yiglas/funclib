using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class PrintLn :
        IFunctionParams<object, object>
    {
        public object Invoke(params object[] more)
        {
            new Apply().Invoke(new Print(), more);
            Variables.Out.Write(Environment.NewLine);
            Variables.Out.Flush();
            return null;
        }
    }
}
