using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class UpdateIn :
        IFunctionParams<object, object, object, object, object>
    {
        public object Invoke(object m, object ks, object f, params object[] args) => up(m, ks, f, args);

        object up(object m, object ks, object f, object args)
        {
            var k = new First().Invoke(ks);
            ks = new Rest().Invoke(ks);

            if ((bool)new Truthy().Invoke(ks))
                return new Assoc().Invoke(m, k, up(new Get().Invoke(m, k), ks, f, args));

            return new Assoc().Invoke(m, k, new Apply().Invoke(f, new Get().Invoke(m, k), args));
        }
    }
}
