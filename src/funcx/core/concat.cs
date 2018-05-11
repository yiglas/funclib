using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class Concat<T> :
        IFunction<IEnumerable<T>>,
        IFunction<IEnumerable<T>, IEnumerable<T>>,
        IFunction<IEnumerable<T>, IEnumerable<T>, IEnumerable<T>>,
        IFunctionParams<IEnumerable<T>, IEnumerable<T>, IEnumerable<T>, IEnumerable<T>>
    {
        public IEnumerable<T> Invoke()
        {
            yield break;
        }

        public IEnumerable<T> Invoke(IEnumerable<T> x) => Invoke(x, null, new T[] { });
        public IEnumerable<T> Invoke(IEnumerable<T> x, IEnumerable<T> y) => Invoke(x, y, new T[] { });
        public IEnumerable<T> Invoke(IEnumerable<T> x, IEnumerable<T> y, params IEnumerable<T>[] zs)
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
