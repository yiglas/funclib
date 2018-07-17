using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace funclib.Components.Core
{
    public class Or :
        IFunction<object>,
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        public object Invoke() => null;
        public object Invoke(object x) => x;
        public object Invoke(object x, params object[] next)
        {
            if (x != null)
            {
                if (x.GetType().GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IFunction<>)))
                {
                    dynamic f = x;
                    x = f.Invoke();
                }
            }

            if ((bool)new Truthy().Invoke(x))
                return x;

            if ((next?.Length ?? 0) <= 0)
                return x;

            return Invoke(next[0], next.Skip(1).ToArray());            
        }
    }
}
