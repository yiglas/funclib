using System;
using System.Text;

namespace funclib.Collections
{
    public interface IMap :
        IAssociative,
        ICollection,
        IEditableCollection,
        IMapEnumerable,
        ICounted,
        System.Collections.IDictionary,
        System.Collections.IEnumerable
    {
        new bool ContainsKey(object key);
        new int Count { get; }
        new IMap Assoc(object key, object val);
        new IMap Cons(object o);

        IMap Without(object key);
    }
}
