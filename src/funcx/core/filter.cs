using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Filter<T> :
        IFunction<IFunction<T, bool>, IEnumerable<T>, IEnumerable<T>>
    {
        public IEnumerable<T> Invoke(IFunction<T, bool> pred, IEnumerable<T> coll) =>
            new Truthy().Invoke(coll)
                ? coll.Where(pred.Invoke)
                : null;
    }
}
