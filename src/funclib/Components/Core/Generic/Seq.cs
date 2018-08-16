using funclib.Collections.Generic;
using System;

namespace funclib.Components.Core.Generic
{
    public class Seq<T> :
        IFunction<object, ISeq<T>>
    {
        public ISeq<T> Invoke(object coll) => throw new NotImplementedException();
    }
}
