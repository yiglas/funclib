using System;
using System.Text;

namespace funcx.Collections
{
    public interface IStack :
        ICollection
    {
        object Peek();
        IStack Pop();
    }
}
