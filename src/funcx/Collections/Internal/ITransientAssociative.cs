using System;
using System.Text;

namespace funcx.Collections.Internal
{
    interface ITransientAssociative :
        ITransientCollection,
        IGetValue
    {
        bool ContainsKey(object key);
        ITransientAssociative Assoc(object key, object val);
        System.Collections.Generic.KeyValuePair<object, object>? Get(object key);
    }
}
