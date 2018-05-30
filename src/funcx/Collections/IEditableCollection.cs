using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IEditableCollection
    {
        ITransientCollection ToTransient();
    }
}
