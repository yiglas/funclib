using System;
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
