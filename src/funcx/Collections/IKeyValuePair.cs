using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IKeyValuePair
    {
        object Key { get; }
        object Value { get; }
    }
}
