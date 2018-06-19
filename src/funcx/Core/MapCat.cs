using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class MapCat :
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        public object Invoke(object f) => new Comp().Invoke(new Map().Invoke(f), new Cat());
        public object Invoke(object f, params object[] colls) => new Apply().Invoke(new Concat(), new Apply().Invoke(new Map(), f, colls));
    }
}
