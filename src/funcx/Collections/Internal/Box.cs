using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    class Box
    {
        public object Value { get; set; }

        public Box(object value)
        {
            Value = value;
        }
    }
}
