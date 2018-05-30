using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IStack :
        ICollection
    {
        object Peek();
        IStack Pop();
    }
}
