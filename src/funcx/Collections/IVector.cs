using System;
using System.Text;

namespace funcx.Collections
{
    public interface IVector:
        IAssociative,
        ICollection,
        IEditableCollection,
        IStack,
        System.Collections.IList,
        System.Collections.Generic.IList<object>,
        System.Collections.Generic.IEnumerable<object>,
        System.Collections.IEnumerable
    {
        new int Count { get; }
        new IVector Cons(object o);
        new bool ContainsKey(object key);
        new System.Collections.Generic.KeyValuePair<int, object>? Get(object key);
        
        new object this[int index] { get; set; }
        object this[int index, object notFound] { get; set; }

        IVector Assoc(int i, object val);
    }
}
