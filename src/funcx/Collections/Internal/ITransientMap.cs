using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections.Internal
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
