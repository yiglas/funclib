using System;
using System.Text;

namespace funcx.Collections
{
    public interface IEnumerative :
        ICollection
    {
        new IEnumerative Cons(object o);

        object First();
        IEnumerative Next();
        IEnumerative More();
    }
}
