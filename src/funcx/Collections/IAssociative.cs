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
        IKeyValuePair Get(object key);
    }
}
