using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface ICollection :
        ISeqable,
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
