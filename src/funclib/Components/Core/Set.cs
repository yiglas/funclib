using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Set :
        IFunction<object, object>
    {
        public object Invoke(object coll) =>
            (bool)new IsSet().Invoke(coll)
                ? coll
                : coll is IReduce r ? new Persistentǃ().Invoke(r.Reduce(new Conjǃ(), new Transient().Invoke(new HashSet().Invoke())))
                : new Persistentǃ().Invoke(new Reduce1().Invoke(new Conjǃ(), new Transient().Invoke(new HashSet().Invoke()), coll));
    }
}
