using funcx.Collections;
using System;
using System.Text;

namespace funcx.Core
{
    public class Next:
        IFunction<object, IEnumerative>
    {
        public IEnumerative Invoke(object coll)
        {
            var enumerate = coll as IEnumerative ?? new Core.Enumerate().Invoke(coll);
            if (enumerate == null)
                return null;
            return enumerate.Next();
        }
    }
}
