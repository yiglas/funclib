using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Rem :
        IFunction<object, object, object>
    {
        public object Invoke(object num, object div) => Numbers.Remainder(num, div);
    }
}
