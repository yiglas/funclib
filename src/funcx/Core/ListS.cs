using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ListS :
        IFunction<object, ISeq>,
        IFunction<object, object, ISeq>,
        IFunction<object, object, object, ISeq>,
        IFunction<object, object, object, object, ISeq>,
        IFunctionParams<object, object, object, object, object, ISeq>

    {
        public ISeq Invoke(object args) => new Seq().Invoke(args);
        public ISeq Invoke(object a, object args) => new Cons().Invoke(a, args);
        public ISeq Invoke(object a, object b, object args) => new Cons().Invoke(a, new Cons().Invoke(b, args));
        public ISeq Invoke(object a, object b, object c, object args) => new Cons().Invoke(a, new Cons().Invoke(b, new Cons().Invoke(c, args)));
        public ISeq Invoke(object a, object b, object c, object d, params object[] more) => 
            new Cons().Invoke(a, new Cons().Invoke(b, new Cons().Invoke(c, new Cons().Invoke(d, new Spread().Invoke(more)))));
    }
}
