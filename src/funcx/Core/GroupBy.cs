using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class GroupBy :
        IFunction<object, object, object>
    {
        public object Invoke(object f, object coll) =>
            new Persistent().Invoke(
                new Reduce().Invoke(
                    new Function<object, object, object>((ret, x) =>
                    {
                        var k = ((IFunction<object, object>)f).Invoke(x);
                        return new AssocT().Invoke(ret, k, new Conj().Invoke(new Get().Invoke(ret, k, new Vector().Invoke()), x));
                    }), new Transient().Invoke(new HashMap().Invoke()), coll));
    }

}
