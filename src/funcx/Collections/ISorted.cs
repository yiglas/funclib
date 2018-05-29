using System;
using System.Text;

namespace funcx.Collections
{
    public interface ISorted
    {
        System.Collections.IComparer GetComparator();
        IEnumerative Enumerate(bool ascending);
        IEnumerative Enumerate(object key, bool ascending);
    }
}
