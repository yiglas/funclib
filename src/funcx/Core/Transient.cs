using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Transient :
        IFunction<object, object>
    {
        public object Invoke(object coll) => ((IEditableCollection)coll).ToTransient();
    }
}
