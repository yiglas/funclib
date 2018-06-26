using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Set :
        IFunction<object, object>
    {
        public object Invoke(object coll) =>
            (bool)new IsSet().Invoke(coll)
                ? coll
                : coll is IReduce r ? new Persistentǃ().Invoke(r.Reduce(new ConjT(), new Transient().Invoke(new HashSet().Invoke())))
                : new Persistentǃ().Invoke(new Reduce1().Invoke(new ConjT(), new Transient().Invoke(new HashSet().Invoke()), coll));
    }
}
