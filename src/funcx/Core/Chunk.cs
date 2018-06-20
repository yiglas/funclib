using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Chunk :
        IFunction<object, object>
    {
        public object Invoke(object b) => ((Collections.ChunkBuffer)b).Chunk();
    }
}
