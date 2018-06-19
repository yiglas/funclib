using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class UUID :
        IFunction<object>
    {
        public object Invoke() => System.Guid.NewGuid();
    }
}
