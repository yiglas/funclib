using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections
{
    public interface ITransientCollection
    {
        int Count { get; }
        ITransientCollection Conj(object val);
        ICollection ToPersistent();
    }
}
