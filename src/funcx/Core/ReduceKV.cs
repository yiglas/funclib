using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ReduceKV :
        IFunction<object, object, object, object>
    {
        public object Invoke(object f, object init, object coll) =>
            coll == null
                ? init
                : coll is IReduceKV r ? r.ReduceKV((IFunction<object, object, object, object>)f, init)
                : coll is IMap m ? new Reduce().Invoke(new Function<object, object, object>((ret, kv) =>
                {
                    var k = new Key().Invoke(kv);
                    var v = new Value().Invoke(kv);

                    return ((IFunction<object, object, object, object>)f).Invoke(ret, k, v);
                }), init, coll)
                : throw new InvalidCastException($"Unable to cast object of type '{coll.GetType().FullName}' to type '{typeof(IReduceKV).FullName}'.");
    }
}
