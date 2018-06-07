using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Reverse :
        IFunction<object, object>
    {
        public object Invoke(object coll) => new Reduce1().Invoke(new Conj(), Collections.List.EMPTY, coll);
    }
}
