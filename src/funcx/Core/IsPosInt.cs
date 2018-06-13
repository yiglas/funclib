using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsPosInt :
        IFunction<object, object>
    {
        public object Invoke(object n) =>
            new And().Invoke(
                new Function<object>(() => new IsInt().Invoke(n)),
                new Function<object>(() => new IsPos().Invoke(n)));
    }
}
