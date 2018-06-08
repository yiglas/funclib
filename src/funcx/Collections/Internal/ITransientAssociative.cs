using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    interface ITransientAssociative :
        ITransientCollection,
        IGetValue
    {
        bool ContainsKey(object key);
        ITransientAssociative Assoc(object key, object val);
        IKeyValuePair Get(object key);
    }
}
