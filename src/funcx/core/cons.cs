using funcx.Collections;
using System;
using System.Text;

namespace funcx.Core
{
    public class Cons :
        IFunction<object, object, IEnumerative>
    {
        public IEnumerative Invoke(object x, object seq)
        {
            if (seq == null) return new List(x);
            if (seq is IEnumerative e) return new Collections.Cons(x, e);
            return new Collections.Cons(x, new Enumerate().Invoke(seq));
        }
    }
}
