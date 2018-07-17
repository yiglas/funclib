using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Repeatedly :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object f) =>
            new LazySeq(() => new Cons().Invoke(((IFunction<object>)f).Invoke(), new Repeatedly().Invoke(f)));
        public object Invoke(object n, object f) => new Take().Invoke(n, Invoke(f));
    }
}
