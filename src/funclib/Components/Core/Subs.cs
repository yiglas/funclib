using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    public class Subs :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke(object s, object start) => ((string)s).Substring((int)start);
        public object Invoke(object s, object start, object end) => ((string)s).Substring((int)start, ((int)end - (int)start));
    }
}
