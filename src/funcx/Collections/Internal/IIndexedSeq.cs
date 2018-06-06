using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    interface IIndexedSeq :
        ISeq
    {
        int Index();
    }
}
