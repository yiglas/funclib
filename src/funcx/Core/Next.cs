using System;
using System.Collections.Generic;
using System.Text;
using f = funcx.Collections;

namespace funcx.Core
{
    public class Next<T> :
        IFunction<IEnumerable<T>, IEnumerable<T>>
    {
        public IEnumerable<T> Invoke(IEnumerable<T> coll) =>
            new First<T>().Invoke(coll) == null
                ? null
                //: coll is f.ICollection c ? c.Next() as IEnumerable<T>
                : inter(coll);

        IEnumerable<T> inter(IEnumerable<T> coll)
        {
            int i = 0;

            foreach (var item in coll)
                if (i++ == 0) continue; else yield return item;
        }
    }
}
