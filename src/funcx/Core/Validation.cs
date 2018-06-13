using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Falsy :
        IFunction<object, object>
    {
        public object Invoke(object source)
        {
            if (source == null) return true;
            else if (source is bool b) return !b;
            else return false;
        }
    }

    public class Truthy :
        IFunction<object, object>
    {
        public object Invoke(object source) => !((bool)(new Falsy().Invoke(source)));
    }
}
