using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Frequencies :
        IFunction<object, object>
    {
        public object Invoke(object coll) =>
            new Persistentǃ().Invoke(
                new Reduce().Invoke(
                    new Function<object, object, object>((counts, x) =>
                        new Assocǃ().Invoke(counts, x, new Inc().Invoke(new Get().Invoke(counts, x, 0)))),
                    new Transient().Invoke(new HashMap().Invoke()), coll));
    }
}
