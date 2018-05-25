using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class Interleave :
        IFunction<IEnumerable, IEnumerable<object>>,
        IFunction<IEnumerable, IEnumerable, IEnumerable<object>>,
        IFunctionParams<IEnumerable, IEnumerable, IEnumerable, IEnumerable<object>>
    {
        public IEnumerable<object> Invoke(IEnumerable c1)
        {
            if (c1 == null) yield break;

            var e1 = c1.GetEnumerator();

            while (e1.MoveNext())
            {
                yield return e1.Current;
            }
        }

        public IEnumerable<object> Invoke(IEnumerable c1, IEnumerable c2)
        {
            if (c1 == null || c2 == null) yield break;

            var e1 = c1.GetEnumerator();
            var e2 = c2.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {
                yield return e1.Current;
                yield return e2.Current;
            }
        }

        public IEnumerable<object> Invoke(IEnumerable c1, IEnumerable c2, params IEnumerable[] colls)
        {
            throw new NotImplementedException("TODO: implement this function. need to get apply to work");
        }
    }
}
