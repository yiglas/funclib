using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Transient :
        IFunction<object, object>
    {
        public object Invoke(object coll) =>
            coll is IEditableCollection ec
                ? ec.ToTransient()
                : throw new InvalidCastException($"{coll.GetType().FullName} cannot be casted to {typeof(IEditableCollection).FullName}");
    }
}
