using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsInstance :
        IFunction<object, object, object>
    {
        public object Invoke(object c, object x) =>
            c is Type t
                ? t.IsInstanceOfType(x)
                : throw new InvalidCastException($"{c.GetType().FullName} cannot be casted to {typeof(Type).FullName}");
    }
}
