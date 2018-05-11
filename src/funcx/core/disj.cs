using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace funcx.Core
{
    public class Disj<T> :
        IFunction<IList<T>, T, IList<T>>,
        IFunctionParams<IList<T>, T, IList<T>>
    {
        public IList<T> Invoke(IList<T> coll, T x) => Invoke(coll, new T[] { x });
        public IList<T> Invoke(IList<T> coll, params T[] xs)
        {
            if (coll == null) return null;

            var remove = xs.ToList();

            var items = coll.Where(x => !remove.Contains(x));

            var list = Activator.CreateInstance(coll.GetType(), items) as IList<T>;

            return list;
        }
    }
}
