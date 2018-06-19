using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsSorted :
        IFunction<object, object>
    {
        public object Invoke(object coll) => new IsInstance().Invoke(typeof(ISorted), coll);
    }
}
