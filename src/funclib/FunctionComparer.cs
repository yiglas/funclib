using funclib.Components.Core;
using funclib.Components.Core.Generic;
using System;
using System.Text;

namespace funclib
{
    class FunctionComparer : System.Collections.IComparer
    {
        IFunction<object, object, object> _comparator;

        public FunctionComparer(object comparator)
        {
            this._comparator = (IFunction<object, object, object>)comparator;
        }

        public int Compare(object x, object y)
        {
            var result = this._comparator.Invoke(x, y);
            if (result is bool b)
                result = b ? -1 : 1;

            return Numbers.ConvertToInt(result);
        }
    }
}
