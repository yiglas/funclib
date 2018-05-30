using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface ITransientCollection
    {
        int Count { get; }
        ITransientCollection Conj(object val);
        ICollection ToPersistent();
    }
}
