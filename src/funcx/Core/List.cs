using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class List :
        IFunctionParams<object, object>
    {
        public object Invoke(params object[] items) => Collections.List.Create(items);
    }
}
