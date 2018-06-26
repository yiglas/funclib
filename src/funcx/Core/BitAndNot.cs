using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class BitAndNot :
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object x, object y) => Numbers.AndNot(x, y);
        public object Invoke(object x, object y, params object[] more) => new Reduce1().Invoke(this, Invoke(x, y), more);
    }
}
