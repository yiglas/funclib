using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace funcx.Core
{
    //public class Disj :
    //    IFunction<IList, IList>,
    //    IFunction<IList, object, IList>,
    //    IFunctionParams<IList, object, object, IList>
    //{
    //    public IList Invoke(IList set) => set;
    //    public IList Invoke(IList set, object key) => Invoke(set, new object[] { key });
    //    public IList Invoke(IList set, object key, params object[] ks)
    //    {
    //        if (set == null) return null;
            
    //        var items = set.Where(x => key != x || !ks.Contains(x));

    //        var list = Activator.CreateInstance(set.GetType(), items) as IList;

    //        return list;
    //    }
    //}
}
