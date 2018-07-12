using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Truthy :
        IFunction<object, object>
    {
        public object Invoke(object source) => !((bool)(new Falsy().Invoke(source)));
    }
}
