using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IMap :
        IAssociative,
        ICollection,
        IEditableCollection,
        IMapEnumerable,
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
