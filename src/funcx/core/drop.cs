using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class Drop<T> :
        IFunction<int, IEnumerable<T>, IEnumerable<T>>
    {
        public IEnumerable<T> Invoke(int n, IEnumerable<T> coll)
        {
            if (new Truthy().Invoke(new And().Invoke(coll, n > 0)))
            {
                int i = 1;
                foreach (var item in coll)
                    if (i++ <= n) continue; else yield return item;
            }

            yield break;
        }
    }
}
