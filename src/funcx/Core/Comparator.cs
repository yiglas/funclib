using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Comparator :
        IFunction<object, object>
    {
        public object Invoke(object pred)
        {
            var p = (IFunction<object, object, object>)pred;

            return new Function<object, object, object>((x, y) =>
            {
                if ((bool)new Truthy().Invoke(p.Invoke(x, y)))
                    return -1;
                else if ((bool)new Truthy().Invoke(p.Invoke(y, x)))
                    return 1;
                else
                    return 0;
            });
        }
    }
}
