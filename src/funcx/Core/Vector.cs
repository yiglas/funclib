using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Vector :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunction<object, object, object, object, object, object>,
        IFunction<object, object, object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object, object, object>
    {
        public object Invoke() => Collections.Vector.EMPTY;
        public object Invoke(object a) => Collections.Vector.Create(a);
        public object Invoke(object a, object b) => Collections.Vector.Create(a, b);
        public object Invoke(object a, object b, object c) => Collections.Vector.Create(a, b, c);
        public object Invoke(object a, object b, object c, object d) => Collections.Vector.Create(a, b, c, d);
        public object Invoke(object a, object b, object c, object d, object e) => Collections.Vector.Create(a, b, c, d, e);
        public object Invoke(object a, object b, object c, object d, object e, object f) => Collections.Vector.Create(a, b, c, d, e, f);
        public object Invoke(object a, object b, object c, object d, object e, object f, params object[] args) =>
            Collections.Vector.Create((ISeq)new Cons().Invoke(a, new Cons().Invoke(b, new Cons().Invoke(c, new Cons().Invoke(d, new Cons().Invoke(e, new Cons().Invoke(f, args)))))));
    }
}
