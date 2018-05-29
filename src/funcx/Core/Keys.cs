using funcx.Collections;
using funcx.Collections.Internal;
using System;
using System.Text;

namespace funcx.Core
{
    public class Keys :
        IFunction<object, IEnumerative>
    {
        public IEnumerative Invoke(object coll)
        {
            if (coll is IMap map)
                return KeyEnumerative.Create(map);

            return KeyEnumerative.Create(new Enumerate().Invoke(coll));
        }
    }
}
