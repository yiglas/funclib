using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Collections.Internal
{
    interface IBoundsCheck
    {
        bool ExceededBounds(object val);
    }
}
