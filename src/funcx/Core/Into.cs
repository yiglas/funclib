using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Into :
        IFunction<object, object, object>
    {
        public object Invoke(object to, object from)
        {
            var ret = to;
            var items = new Seq().Invoke(from);
            if ((bool)new Truthy().Invoke(items))
            {
                return Invoke(new Conj().Invoke(ret, new First().Invoke(items)), new Next().Invoke(items));
            }
            return ret;
        }
    }
}
