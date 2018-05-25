using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class Cons :
        IFunction<object, IEnumerable, IEnumerable>
    {
        public IEnumerable Invoke(object x, IEnumerable seq)
        {
            yield return x;

            if (seq != null)
                foreach (var item in seq)
                    yield return item;
        }
    }
}
