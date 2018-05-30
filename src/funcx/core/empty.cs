using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Empty<T> :
        IFunction<ICollection<T>, ICollection<T>>
    {
        public ICollection<T> Invoke(ICollection<T> coll) =>
            coll == null
                ? null
                : Activator.CreateInstance(coll.GetType()) as ICollection<T>;
    }
}
