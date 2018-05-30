using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IMapEnumerable
    {
        System.Collections.IEnumerator GetKeyEnumerator();
        System.Collections.IEnumerator GetValueEnumerator();
    }
}
