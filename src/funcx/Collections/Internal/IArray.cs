using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    interface IArray :
        ISeq,
        IIndexedSeq,
        System.Collections.IList
    {
        object[] ToArray();
        object Array();
    }
}
