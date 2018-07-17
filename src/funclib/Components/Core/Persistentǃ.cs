using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Persistentǃ :
        IFunction<object, object>
    {
        public object Invoke(object coll) => ((ITransientCollection)coll).ToPersistent();
    }
}
