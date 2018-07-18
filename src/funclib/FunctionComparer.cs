using funclib.Components.Core;
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

        public int Compare(object x, object y) => Numbers.ConvertToInt(this._comparator.Invoke(x, y));
    }
}
