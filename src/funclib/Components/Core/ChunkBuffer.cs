using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class ChunkBuffer :
        IFunction<object, object>
    {
        public object Invoke(object capacity) => new Collections.ChunkBuffer(Numbers.ConvertToInt(capacity));
    }
}
