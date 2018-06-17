using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class NotEmpty :
        IFunction<object, object>
    {
        public object Invoke(object coll) =>
            (bool)new Truthy().Invoke(new Seq().Invoke(coll))
                ? coll
                : null;
    }
}
