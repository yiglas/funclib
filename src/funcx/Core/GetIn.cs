using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class GetIn :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke(object m, object ks) => new Reduce1().Invoke(new Get(), m, ks);
        public object Invoke(object m, object ks, object notFound) =>
            loop(new object(), m, (ISeq)new Seq().Invoke(ks), notFound);

        object loop(object sentinel, object m, ISeq ks, object notFound)
        {
            if ((bool)new Truthy().Invoke(ks))
            {
                m = new Get().Invoke(m, ks.First(), sentinel);
                if ((bool)new IsIdentical().Invoke(m, sentinel))
                    return notFound;

                return loop(sentinel, m, ks.Next(), notFound);
            }

            return m;
        }
    }
}
