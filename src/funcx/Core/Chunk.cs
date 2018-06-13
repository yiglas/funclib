using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Chunk :
        IFunction<object, object>
    {
        public object Invoke(object b) =>
            b is Collections.ChunkBuffer cb
                ? cb.Chunk()
                : throw new InvalidCastException($"{b.GetType().FullName} cannot be casted to {typeof(Collections.ChunkBuffer).FullName}");
    }
}
