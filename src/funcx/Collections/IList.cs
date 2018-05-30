using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IList : 
        IStack,
        ISeq,
        ICollection,
        System.Collections.IList,
        System.Collections.ICollection,
        System.Collections.Generic.IList<object>,
        System.Collections.Generic.ICollection<object>,
        System.Collections.IEnumerable,
        System.Collections.Generic.IEnumerable<object>
    {
        new object this[int index] { get; set; }
        new int Count { get; }
    }
}
