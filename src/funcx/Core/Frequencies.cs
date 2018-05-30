using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    //public class Frequencies<T> :
    //    IFunction<IEnumerable<T>, IDictionary<T, int>>
    //{
    //    public IDictionary<T, int> Invoke(IEnumerable<T> coll) =>
    //        new Reduce<IDictionary<T, int>, T>().Invoke(
    //            new Function<IDictionary<T, int>, T, IDictionary<T, int>>(
    //                (counts, x) => 
    //                    new AssocT<T, int>().Invoke(
    //                        counts, 
    //                        (x, new Inc().Invoke(new Get<T, int>().Invoke(counts, x, 0))))),
    //            new Dictionary<T, int>(),
    //            coll);
    //}
}
