using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace funcx.Core
{
    //public class Conj :
    //    IFunction<IEnumerable>,
    //    IFunction<IEnumerable, IEnumerable>,
    //    IFunction<IEnumerable, object, IEnumerable>,
    //    IFunctionParams<IEnumerable, object, object, IEnumerable>
    //{
    //    public IEnumerable Invoke() => new object[] { };
    //    public IEnumerable Invoke(IEnumerable coll) => coll;
    //    public IEnumerable Invoke(IEnumerable coll, object x)
    //    {
    //        if (coll == null) return new object[] { x };

    //        var list = Activator.CreateInstance(coll.GetType(), coll) as IEnumerable;

    //        list.OfType<object>().Concat(new object[] { x });

    //        return list;
    //    }
    //    public IEnumerable Invoke(IEnumerable coll, object x, params object[] xs)
    //    {
    //        //if (coll == null)

    //            var list = Activator.CreateInstance(coll.GetType(), coll) as IEnumerable;

    //        list.Add(x);
    //        for (int i = 0; i < xs.Length; i++)
    //            list.Add(xs[i]);

    //        return list;
    //    }
    //}

    //public class ConjT :
    //    IFunction<IEnumerable>,
    //    IFunction<IEnumerable, IEnumerable>,
    //    IFunction<IEnumerable, object, IEnumerable>,
    //    IFunctionParams<IEnumerable, object, object, IEnumerable>
    //{
    //    public IEnumerable Invoke() => new object[] { };
    //    public IEnumerable Invoke(IEnumerable coll) => coll;
    //    public IEnumerable Invoke(IEnumerable coll, object x)
    //    {
    //        if (coll == null) return new object[] { x };

    //        coll.Add(x);

    //        return coll;
    //    }
    //    public IEnumerable Invoke(IEnumerable coll, object x, params object[] xs)
    //    {
    //        if (coll == null) return new List<T>() { x };

    //        list.Add(x);
    //        for (int i = 0; i < xs.Length; i++)
    //            list.Add(xs[i]);

    //        return list;
    //    }

    //}
}
