using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Last :
        IFunction<object, object>
    {
        public object Invoke(object s)
        {
            var n = new Next().Invoke(s);
            if ((bool)new Truthy().Invoke(n))
                return Invoke(n);

            return new First().Invoke(s);
        }
            
    }
}
