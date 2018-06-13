using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ChunkBuffer :
        IFunction<object, object>
    {
        public object Invoke(object capacity) => new Collections.ChunkBuffer(Numbers.ConvertToInt(capacity));
    }
}
