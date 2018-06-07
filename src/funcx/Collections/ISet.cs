using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface ISet :
        ICollection,
        IEditableCollection,
        System.Collections.ICollection
    {
        new int Count { get; }

        bool Contains(object key);
        ISet Disj(object key);
        object Get(object key);
    }
}
