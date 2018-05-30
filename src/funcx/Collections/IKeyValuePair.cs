using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IKeyValuePair
    {
        object Key { get; }
        object Value { get; }
    }
}
