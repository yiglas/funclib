using System;
using System.Text;

namespace funcx.Collections
{
    public interface IEnumerative :
        ICollection,
        System.Collections.IEnumerable,
        System.Collections.Generic.IEnumerable<object>
    {
        new IEnumerative Cons(object o);

        object First();
        IEnumerative Next();
        IEnumerative More();
    }
}
