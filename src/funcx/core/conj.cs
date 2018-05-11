using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace funcx.Core
{
    public class Conj<T> :
        IFunction<IList<T>, T, IList<T>>,
        IFunctionParams<IList<T>, T, IList<T>>
    {
        public IList<T> Invoke(IList<T> coll, T x) => Invoke(coll, new T[] { x });
        public IList<T> Invoke(IList<T> coll, params T[] xs)
        {
            if (coll == null && !xs.Any()) return new List<T>();

            if (coll == null && xs.Any())
                return new List<T>(xs);
            else
            {
                var items = new T[coll.Count + xs.Count()];
                Array.Copy(coll.ToArray(), 0, items, 0, coll.Count);
                Array.Copy(xs, 0, items, coll.Count, xs.Length);

                var list = Activator.CreateInstance(coll.GetType(), items) as IList<T>;

                return list;
            }
        }
    }
}
