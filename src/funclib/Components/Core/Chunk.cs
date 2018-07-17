using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Chunk :
        IFunction<object, object>
    {
        public object Invoke(object b) => ((Collections.ChunkBuffer)b).Chunk();
    }
}
