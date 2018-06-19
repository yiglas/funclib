using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ConjT :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke() => new Transient().Invoke(new Vector().Invoke());
        public object Invoke(object coll) => coll;
        public object Invoke(object coll, object x) =>
            ((ITransientCollection)coll).Conj(x);
    }
}
