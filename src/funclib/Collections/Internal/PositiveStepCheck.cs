using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Collections.Internal
{
    class PositiveStepCheck : 
        IBoundsCheck
    {
        object _end;

        public PositiveStepCheck(object end)
        {
            this._end = end;
        }

        public bool ExceededBounds(object val) => Numbers.IsGTE(val, this._end);
    }
}
