using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Empty :
        IFunction<object, object>
    {
        public object Invoke(object coll) =>
            coll != null && coll is ICollection c
                ? c.Empty()
                : null;
    }
}
