using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Repeat<T> :
        IFunction<T, IEnumerable<T>>,
        IFunction<int, T, IEnumerable<T>>
    {
        public IEnumerable<T> Invoke(T x)
        {
            while (true)
            {
                yield return x;
            }
        }

        public IEnumerable<T> Invoke(int n, T x)
        {
            if (n <= 0) yield break;

            for (int i = 0; i < n; i++)
                yield return x;
        }
    }
}
