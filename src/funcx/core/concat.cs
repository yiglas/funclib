using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class Concat :
        IFunction<IEnumerable>,
        IFunction<IEnumerable, IEnumerable>,
        IFunction<IEnumerable, IEnumerable, IEnumerable>,
        IFunctionParams<IEnumerable, IEnumerable, IEnumerable, IEnumerable>
    {
        public IEnumerable Invoke()
        {
            yield break;
        }

        public IEnumerable Invoke(IEnumerable x) => Invoke(x, null, new object[] { });
        public IEnumerable Invoke(IEnumerable x, IEnumerable y) => Invoke(x, y, new object[] { });
        public IEnumerable Invoke(IEnumerable x, IEnumerable y, params IEnumerable[] zs)
        {
            if (x != null)
                foreach (var item in x)
                    yield return item;

            if (y != null)
                foreach (var item in y)
                    yield return item;

            for (int i = 0; i < zs.Length; i++)
                if (zs[i] != null)
                    foreach (var item in zs[i])
                        yield return item;
        }
    }
}
