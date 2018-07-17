using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Trampoline :
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        public object Invoke(object f)
        {
            var ret = ((IFunction<object>)f).Invoke();
            if ((bool)new IsFunction().Invoke(ret))
                return Invoke(ret);

            return ret;
        }
        public object Invoke(object f, params object[] args) =>
            Invoke(new Function<object>(() => new Apply().Invoke(f, args)));
    }
}
