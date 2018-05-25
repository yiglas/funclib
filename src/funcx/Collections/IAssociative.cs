using System;
using System.Text;

namespace funcx.Collections
{
    public interface IAssociative :
        ICollection,
        IGetValue
    {
        bool ContainsKey(object key);
        IAssociative Assoc(object key, object val);
        System.Collections.Generic.KeyValuePair<object, object>? Get(object key);
    }
}
