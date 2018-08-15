using funclib.Components.Core.Generic;

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
