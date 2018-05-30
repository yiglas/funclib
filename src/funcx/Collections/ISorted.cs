using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface ISorted
    {
        System.Collections.IComparer GetComparator();
        ISeq Seq(bool ascending);
        ISeq Seq(object key, bool ascending);
    }
}
