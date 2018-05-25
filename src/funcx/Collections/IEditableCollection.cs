using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections
{
    public interface IEditableCollection
    {
        ITransientCollection ToTransient();
    }
}
