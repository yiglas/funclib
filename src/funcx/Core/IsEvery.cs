using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsEvery :
        IFunction<object, object, object>
    {
        public object Invoke(object pred, object coll)
        {
            if ((bool)new IsNull().Invoke(new Seq().Invoke(coll))) return true;
            var fn = (IFunction<object, object>)pred;
            if ((bool)new Truthy().Invoke(fn.Invoke(new First().Invoke(coll))))
                return Invoke(pred, new Next().Invoke(coll));
            return false;
        }
    }
}
