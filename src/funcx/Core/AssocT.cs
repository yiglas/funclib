using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class AssocT :
        IFunction<object, object, object, object>,
        IFunctionParams<object, object, object, object, object>
    {
        public object Invoke(object coll, object key, object val) => ((ITransientAssociative)coll).Assoc(key, val);
        public object Invoke(object coll, object key, object val, params object[] kvs)
        {
            var ret = ((ITransientAssociative)coll).Assoc(key, val);
            if ((bool)new Truthy().Invoke(kvs))
                return Invoke(ret, new First().Invoke(kvs), new Second().Invoke(kvs), new NNext().Invoke(kvs));

            return ret;
        }
    }
}
