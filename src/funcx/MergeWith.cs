using FunctionalLibrary.Core;
using System;
using System.Text;

namespace FunctionalLibrary
{
    public class MergeWith :
        IFunctionParams<object, object, object>
    {
        public object Invoke(object f, params object[] maps)
        {
            if ((bool)new Truthy().Invoke(new Some().Invoke(new Identity(), maps)))
            {
                return new Reduce1().Invoke(new Function<object, object, object>(merge2), maps);
            }

            return null;

            object mergeEntry(object m, object e)
            {
                var k = new Key().Invoke(e);
                var v = new Value().Invoke(e);
                if ((bool)new Contains().Invoke(m, k))
                {
                    return new Assoc().Invoke(m, k, ((IFunction<object, object, object>)f).Invoke(new Get().Invoke(m, k), v));
                }

                return new Assoc().Invoke(m, k, v);
            }

            object merge2(object m1, object m2) => new Reduce1().Invoke(new Function<object, object, object>(mergeEntry), (new Or().Invoke(m1, new HashMap().Invoke()), new Seq().Invoke(m2)));
        }
    }
}
