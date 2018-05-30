using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface ISeq :
        ICollection,
        System.Collections.IEnumerable,
        System.Collections.Generic.IEnumerable<object>
    {
        new ISeq Cons(object o);

        object First();
        ISeq Next();
        ISeq More();
    }
}
