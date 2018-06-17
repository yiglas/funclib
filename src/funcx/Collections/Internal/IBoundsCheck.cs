using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    interface IBoundsCheck
    {
        bool ExceededBounds(object val);
    }
}
