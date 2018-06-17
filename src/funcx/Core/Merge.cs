using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Merge :
        IFunctionParams<object, object>
    {
        public object Invoke(params object[] maps)
        {
            if ((bool)new Truthy().Invoke(new Some().Invoke(new Identity(), maps)))
            {
                new Reduce1().Invoke(new Function<object, object, object>((_1, _2) => new Conj().Inovke(new Or().Inovke(_1, new HashMap().Invoke()), _2)), maps);
            }

            return null;
        }
    }
}
