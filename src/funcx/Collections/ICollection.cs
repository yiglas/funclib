using System;
using System.Text;

namespace funcx.Collections
{
    public interface ICollection :
        IEnumerateable,
        System.Collections.ICollection,
        System.Collections.Generic.ICollection<object>,
        System.Collections.IEnumerable,
        System.Collections.Generic.IEnumerable<object>
    {
        new int Count { get; }
        ICollection Cons(object o);
        ICollection Empty();
    }
}
