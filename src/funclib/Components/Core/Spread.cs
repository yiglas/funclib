using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    class Spread :
        IFunction<object, object>
    {
        public object Invoke(object argList)
        {
            if (argList is null) return null;
            var n = funclib.Core.Next(argList);
            if (n is null)
                return funclib.Core.Seq(funclib.Core.First(argList));

            return funclib.Core.Cons(funclib.Core.First(argList), Invoke(n));
        }
    }
}
