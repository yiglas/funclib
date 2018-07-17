using System;
using System.Text;

namespace funclib.Collections
{
    public interface IStack :
        ICollection
    {
        object Peek();
        IStack Pop();
    }
}
