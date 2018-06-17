using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class DoRun :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object coll)
        {
            var s = new Seq().Invoke(coll);
            if ((bool)new Truthy().Invoke(s))
            {
                return Invoke(new Next().Invoke(s));
            }
            return null;
        }
        public object Invoke(object n, object coll)
        {
            var s = new Seq().Invoke(coll);            
            if ((bool)new Truthy().Invoke(s) && (bool)new IsPos().Invoke(n))
            {
                return Invoke(new Dec().Invoke(n), new Next().Invoke(s));
            }
            return null;
        }
    }
}
