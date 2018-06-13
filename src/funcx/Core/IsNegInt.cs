using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsNegInt :
        IFunction<object, object>
    {
        public object Invoke(object n) =>
            new And().Invoke(
                new Function<object>(() => new IsInt().Invoke(n)),
                new Function<object>(() => new IsNeg().Invoke(n)));
    }
}
