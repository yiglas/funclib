using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace funcx.Core
{
    public class Take<T> :
        IFunction<int, IEnumerable<T>, IEnumerable<T>>
    {
        public IEnumerable<T> Invoke(int n, IEnumerable<T> coll) =>
            n <= 0 || new Truthy().Invoke(coll)
                ? new List<T>()
                : inter(n, coll);

        static IEnumerable<T> inter<T>(int n, IEnumerable<T> coll)
        {
            int i = 0;
            foreach (var item in coll)
                if (++i > n) yield break; else yield return item;
        }
    }
}
