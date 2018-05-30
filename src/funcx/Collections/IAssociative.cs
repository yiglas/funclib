using System;
using System.Text;

namespace FunctionalLibrary.Collections
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
