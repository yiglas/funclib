using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsNotEvery :
        IFunction<object>
    {
        public object Invoke() => new Comp().Invoke(new Not(), new IsEvery());
    }
}
