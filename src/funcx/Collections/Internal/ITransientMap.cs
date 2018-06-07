using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    interface ITransientMap :
        ITransientAssociative,
        ITransientCollection
    {
        new IMap ToPersistent();
        new int Count { get; }
        new ITransientMap Assoc(object key, object val);

        ITransientMap Without(object key);
    }
}
