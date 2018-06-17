using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Persistent :
        IFunction<object, object>
    {
        public object Invoke(object coll) => 
            coll is ITransientCollection t
                ? t.ToPersistent()
                : throw new InvalidCastException($"{coll.GetType().FullName} cannot be casted to {typeof(ITransientCollection).FullName}");
    }
}
