using System;
using System.Text;

namespace funclib.Collections
{
    public interface IKeyValuePair
    {
        object Key { get; }
        object Value { get; }
    }
}
