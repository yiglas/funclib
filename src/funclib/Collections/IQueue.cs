using System;
using System.Text;

namespace funclib.Collections
{
    public interface IQueue :
        ISequential,
        IStack,
        ICounted,
        System.Collections.ICollection
    {
    }
}
