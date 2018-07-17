using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Transient :
        IFunction<object, object>
    {
        public object Invoke(object coll) => ((IEditableCollection)coll).ToTransient();
    }
}
