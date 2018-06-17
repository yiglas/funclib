using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class SplitAt :
        IFunction<object, object, object>
    {
        public object Invoke(object n, object coll) =>
            new Vector().Invoke(new Take().Invoke(n, coll), new Drop().Invoke(n, coll));
    }
}
