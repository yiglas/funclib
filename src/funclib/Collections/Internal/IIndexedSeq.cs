using System;
using System.Text;

namespace funclib.Collections.Internal
{
    interface IIndexedSeq :
        ISeq,
        ISequential
    {
        int Index();
    }
}
