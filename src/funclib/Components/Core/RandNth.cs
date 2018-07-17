using System;
using System.Text;

namespace funclib.Components.Core
{
    public class RandNth :
        IFunction<object, object>
    {
        public object Invoke(object coll) => new Nth().Invoke(coll, new RandInt().Invoke(new Count().Invoke(coll)));
    }
}
