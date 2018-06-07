using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IEditableCollection
    {
        ITransientCollection ToTransient();
    }
}
