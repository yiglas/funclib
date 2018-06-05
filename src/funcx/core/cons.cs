using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Cons :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object seq)
        {
            if (seq == null) return new Collections.List(x);
            if (seq is ISeq e) return new Collections.Cons(x, e);
            return new Collections.Cons(x, new Seq().Invoke(seq));
        }
    }
}
