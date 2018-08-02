using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    public interface ITransducerFunction :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        // empty
    }
}
