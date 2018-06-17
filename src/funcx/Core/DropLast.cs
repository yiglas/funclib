using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class DropLast :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object coll) => Invoke(1, coll);
        public object Invoke(object n, object coll) => new Map().Invoke(new Function<object, object, object>((x, _) => x), coll, Invoke(n, coll));
    }
}
