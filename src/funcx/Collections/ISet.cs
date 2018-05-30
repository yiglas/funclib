using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface ISet :
        ICollection,
        IEditableCollection,
        System.Collections.ICollection,
        System.Collections.Generic.ICollection<object>
    {
        new int Count { get; }
        new bool Contains(object key);

        ISet Disj(object key);
        object Get(object key);
    }
}
