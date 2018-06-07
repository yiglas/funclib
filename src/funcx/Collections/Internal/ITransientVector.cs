using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    interface ITransientVector :
        ITransientAssociative
    {
        new IVector ToPersistent();

        object this[int index] { get; set; }
        object this[int index, object notFound] { get; set; }

        ITransientVector Assoc(int i, object val);
        ITransientVector Pop();
    }
}
