using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Equals :
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
                var next = (ISeq)new Next().Invoke(more);
                if (next != null)
                    return Invoke(y, next.First(), next.More());

                return Invoke(y, next.First());
            }

            return false;
        }
    }
}
