using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class DoAll :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object coll)
        {
            new DoRun().Invoke(coll);
            return coll;
        }

        public object Invoke(object n, object coll)
        {
            new DoRun().Invoke(n, coll);
            return coll;
        }
    }
}
