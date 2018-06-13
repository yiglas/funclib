using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsInt :
        IFunction<object, object>
    {
        public object Invoke(object n) =>
            new Or().Invoke(
                new Function<object>(() => n is Int32),
                new Function<object>(() => n is Int64),
                new Function<object>(() => n is Int16),
                new Function<object>(() => n is Byte));
    }
}
