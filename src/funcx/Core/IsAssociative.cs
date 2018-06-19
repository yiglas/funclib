using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsAssociative :
        IFunction<object, object>
    {
        public object Invoke(object coll) => new IsInstance().Invoke(typeof(IAssociative), coll);
    }
}
