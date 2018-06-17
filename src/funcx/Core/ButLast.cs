using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ButLast :
        IFunction<object, object>
    {
        public object Invoke(object s)
        {
            return loop(Collections.Vector.EMPTY, s);
            
            object loop(object ret, object coll)
            {
                var n = new Next().Invoke(coll);
                if ((bool)new Truthy().Invoke(n))
                    return loop(new Conj().Invoke(ret, new First().Invoke(coll)), n);
                return new Seq().Invoke(ret);
            }
        }
    }
}
