using System;
using System.Text;

namespace funclib.Collections
{
    public interface IEditableCollection
    {
        ITransientCollection ToTransient();
    }
}
