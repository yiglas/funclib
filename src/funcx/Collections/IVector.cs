using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IVector:
        IAssociative,
        ICollection,
        IEditableCollection,
        IStack,
        ICounted,
        IReversible,
        System.Collections.IList,
        System.Collections.IEnumerable
    {
        new int Count { get; }
        new IVector Cons(object o);
        new bool ContainsKey(object key);
        new IKeyValuePair Get(object key);
        
        new object this[int index] { get; set; }
        object this[int index, object notFound] { get; set; }

        IVector Assoc(int i, object val);
    }
}
