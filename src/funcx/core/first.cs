using funcx.Collections;
using System;
using System.Text;

namespace funcx.Core
{
    public class First :
        IFunction<object, object>
    {
        public object Invoke(object coll)
        {
            var enumerate = coll as IEnumerative ?? new Core.Enumerate().Invoke(coll);
            if (enumerate == null)
                return null;
            return enumerate.First();
        }
    }
}
