using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    //public class GroupBy<TKey, TValue> :
    //    IFunction<IFunction<TValue, TKey>, IEnumerable<TValue>, IDictionary<TKey, IList<TValue>>>
    //{
    //    public IDictionary<TKey, IList<TValue>> Invoke(IFunction<TValue, TKey> f, IEnumerable<TValue> coll) =>
    //        new Reduce<IDictionary<TKey, IList<TValue>>, TValue>().Invoke(
    //            new Function<IDictionary<TKey, IList<TValue>>, TValue, IDictionary<TKey, IList<TValue>>>(
    //                (ret, x) =>
    //                {
    //                    var k = f.Invoke(x);
    //                    return new AssocT<TKey, IList<TValue>>().Invoke(ret, (k, new Conj<TValue>().Invoke(new Get<TKey, IList<TValue>>().Invoke(ret, k, new List<TValue>()), x)));
    //                }), new Dictionary<TKey, IList<TValue>>(), coll);
    //}
}
