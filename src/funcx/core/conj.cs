using FunctionalLibrary.Collections;
using System;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Conj :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke() => Vector.EMPTY;
        public object Invoke(object coll) => coll;
        public object Invoke(object coll, object x) => 
            coll == null 
                ? new Collections.List(x) 
                : coll is ICollection c ? c.Cons(x)
                : throw new InvalidCastException();

        public object Invoke(object coll, object x, params object[] xs)
        {
            var next = new Next().Invoke(xs);
            if (next != null)
            {
                return Invoke(Invoke(coll, x), new First().Invoke(xs), next);
            }
            else
                return Invoke(coll, x);
        }
    }
}
