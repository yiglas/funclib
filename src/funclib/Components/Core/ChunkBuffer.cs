using funclib.Components.Core.Generic;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class ChunkBuffer :
        IFunction<object, object>
    {
        public object Invoke(object capacity) => new Collections.ChunkBuffer(Numbers.ConvertToInt(capacity));
    }
}
