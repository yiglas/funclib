using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Rem :
        IFunction<object, object, object>
    {
        public object Invoke(object num, object div) => Numbers.Remainder(num, div);
    }
}
