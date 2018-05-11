using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class IsPos :
        IFunction<long, bool>,
        IFunction<int, bool>,
        IFunction<double, bool>,
        IFunction<float, bool>
    {
        public bool Invoke(long n) => n > 0;
        public bool Invoke(int n) => n > 0;
        public bool Invoke(double n) => n > 0;
        public bool Invoke(float n) => n > 0;
    }

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
