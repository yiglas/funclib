using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections.Internal
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
