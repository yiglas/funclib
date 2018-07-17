using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Collections.Internal
{
    class NegativeStepCheck :
        IBoundsCheck
    {
        object _end;

        public NegativeStepCheck(object end)
        {
            this._end = end;
        }

        public bool ExceededBounds(object val) => Numbers.IsLTE(val, this._end);
    }
}
