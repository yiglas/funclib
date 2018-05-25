using System;
using System.Text;

namespace funcx.Collections
{
    public interface IMapEnumerable
    {
        System.Collections.IEnumerator GetKeyEnumerator();
        System.Collections.IEnumerator GetValueEnumerator();
    }
}
