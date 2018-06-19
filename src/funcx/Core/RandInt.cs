using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class RandInt :
        IFunction<object, object>
    {
        public object Invoke(object n) => (int)new Rand().Invoke(n);
    }
}
