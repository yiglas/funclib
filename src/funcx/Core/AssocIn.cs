using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class AssocIn :
        IFunction<object, object, object, object>
    {
        public object Invoke(object m, object ks, object v)
        {
            var k = new First().Invoke(ks);
            ks = new Rest().Invoke(ks);

            if ((bool)new Truthy().Invoke(ks))
                return new Assoc().Invoke(m, k, Invoke(new Get().Invoke(m, k), ks, v));

            return new Assoc().Invoke(m, k, v);
        }
    }
}
