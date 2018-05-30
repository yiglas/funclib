using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Cons :
        IFunction<object, object, ISeq>
    {
        public ISeq Invoke(object x, object seq)
        {
            if (seq == null) return new Collections.List(x);
            if (seq is ISeq e) return new Collections.Cons(x, e);
            return new Collections.Cons(x, new Seq().Invoke(seq));
        }
    }
}
