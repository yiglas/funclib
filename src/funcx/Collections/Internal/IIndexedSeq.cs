using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    interface IIndexedSeq :
        ISeq
    {
        int Index();
    }
}
