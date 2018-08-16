using System;

namespace funclib.Components.Core.Generic
{
    public class Count<T> :
        IFunction<T, int>
    {
        public int Invoke(T coll) => throw new NotImplementedException();
    }
}
