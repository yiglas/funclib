using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    public class Sort :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object coll) => Invoke(new Compare(), coll);
        public object Invoke(object comp, object coll)
        {
            if ((bool)new Truthy().Invoke(new Seq().Invoke(coll)))
            {
                var a = (object[])new ToArray().Invoke(coll);
                Array.Sort(a, new FunctionComparer(comp));
                return new Seq().Invoke(a);
            }
            return new List().Invoke();
        }
            
    }
}
