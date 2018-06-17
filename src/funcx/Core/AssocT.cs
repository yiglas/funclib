using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class AssocT :
        IFunction<object, object, object, object>,
        IFunctionParams<object, object, object, object, object>
    {
        public object Invoke(object coll, object key, object val) =>
            coll is ITransientAssociative t
                ? t.Assoc(key, val)
                : throw new InvalidCastException($"{coll.GetType().FullName} cannot be casted to {typeof(ITransientAssociative).FullName}");

        public object Invoke(object coll, object key, object val, params object[] kvs)
        {
            var t = coll as ITransientAssociative;
            if (t == null)
                throw new InvalidCastException($"{coll.GetType().FullName} cannot be casted to {typeof(ITransientAssociative).FullName}");

            var ret = t.Assoc(key, val);
            if ((bool)new Truthy().Invoke(kvs))
                return Invoke(ret, new First().Invoke(kvs), new Second().Invoke(kvs), new NNext().Invoke(kvs));

            return ret;
        }
    }
}
