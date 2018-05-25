using System;
using System.Text;

namespace funcx.Collections
{
    public interface ISet :
        ICollection,
        IEditableCollection,
        System.Collections.ICollection,
        System.Collections.Generic.ICollection<object>
    {
        new int Count { get; }
        new bool Contains(object key);

        ISet Disjoin(object key);
        object Get(object key);
    }
}
