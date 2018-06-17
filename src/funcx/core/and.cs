using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class And :
        IFunction<object>,
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        public object Invoke() => true;
        public object Invoke(object x)
        {
            if (x != null)
            {
                if (x.GetType().GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IFunction<>)))
                {
                    dynamic f = x;
                    x = f.Invoke();
                }
            }

            return x;
        }

        public object Invoke(object x, params object[] next)
        {
            if (next == null || next.Length <= 0)
                return Invoke(x);

            if (x != null)
            {
                if (x.GetType().GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IFunction<>)))
                {
                    dynamic f = x;
                    x = f.Invoke();
                }
            }

            if ((bool)new Truthy().Invoke(x))
                return Invoke(next[0], next.Skip(1).ToArray());
            
            return x;
        }
    }
}
