using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsDistinct :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object x) => true;
        public object Invoke(object x, object y) => new Not().Invoke(new Equals().Invoke(x, y));
        public object Invoke(object x, object y, params object[] more)
        {
            if ((bool)new NotEqual().Invoke(x, y))
                return loop(new HashSet().Invoke(x, y), more);

            return false;
            

            object loop(object s, object xs)
            {
                var f = new First().Invoke(xs);
                var etc = new Rest().Invoke(xs);

                if ((bool)new Truthy().Invoke(xs))
                {
                    if ((bool)new Contains().Invoke(s, f))
                        return false;

                    return loop(new Conj().Invoke(s, f), etc);
                }
                else return true;
            }
        }
    }
}
