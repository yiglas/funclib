using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class Cons<T> :
        IFunction<T, IEnumerable<T>, IEnumerable<T>>
    {
        public IEnumerable<T> Invoke(T x, IEnumerable<T> seq)
        {
            yield return x;

            if (seq != null)
                foreach (var item in seq)
                    yield return item;
        }
    }
}
