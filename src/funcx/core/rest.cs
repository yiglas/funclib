using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class Rest<T> :
        IFunction<IEnumerable<T>, IEnumerable<T>>
    {
        public IEnumerable<T> Invoke(IEnumerable<T> coll)
        {
            if (coll == null) yield break;

            int i = 0;
            foreach (var item in coll)
                if (i++ == 0) continue; else yield return item;
        }
    }
}
