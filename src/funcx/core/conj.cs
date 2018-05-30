using FunctionalLibrary.Collections;
using System;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Conj :
        IFunction<ICollection>,
        IFunction<ICollection, ICollection>,
        IFunction<ICollection, object, ICollection>,
        IFunctionParams<ICollection, object, object, ICollection>
    {
        public ICollection Invoke() => Vector.EMPTY;
        public ICollection Invoke(ICollection coll) => coll;
        public ICollection Invoke(ICollection coll, object x) => coll == null ? new Collections.List(x) : coll.Cons(x);
        public ICollection Invoke(ICollection coll, object x, params object[] xs)
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
