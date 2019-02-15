using funclib.Components.Core.Generic;

namespace funclib.Components.Core.Internal
{
    class E :
        IFunction<object, bool>,
        IFunction<object, object, bool>,
        IFunctionParams<object, object, object, bool>
    {
        public bool Invoke(object x) => true;
        public bool Invoke(object x, object y)
        {
            if (x == y) return true;
            if (x != null)
            {
                if (Numbers.IsNumber(x) && Numbers.IsNumber(y))
                    return Numbers.IsEqual(x, y);

                return x.Equals(y);
            }

            return false;
        }
        public bool Invoke(object x, object y, params object[] more)
        {
            if (Invoke(x, y))
            {
                var n = funclib.Core.Next(more);
                if (funclib.Core.T(n))
                    return Invoke(y, funclib.Core.First(more), (object[])funclib.Core.ToArray(n));

                return Invoke(y, funclib.Core.First(more));
            }

            return false;
        }
    }
}