using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class ChunkAppend :
        IFunction<object, object, object>
    {
        public object Invoke(object b, object x) => ((Collections.ChunkBuffer)b).Add(x);
    }
}
