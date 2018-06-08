using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Falsy :
        IFunction<object, bool>,
        IFunction<bool, bool>
    {
        public bool Invoke(object source)
        {
            if (source == null) return true;
            else if (source is bool b) return !b;
            else return false;
        }

        public bool Invoke(bool source) => source;
    }

    public class Truthy :
        IFunction<object, bool>,
        IFunction<bool, bool>
    {
        public bool Invoke(object source) => !(new Falsy().Invoke(source));
        public bool Invoke(bool source) => !(new Falsy().Invoke(source));
    }
}
