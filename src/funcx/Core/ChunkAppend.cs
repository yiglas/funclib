using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ChunkAppend :
        IFunction<object, object, object>
    {
        public object Invoke(object b, object x) =>
            b is Collections.ChunkBuffer buffer
                ? buffer.Add(x)
                : throw new InvalidCastException($"{b.GetType().FullName} cannot be casted to {typeof(Collections.ChunkBuffer).FullName}");
    }
}
