using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Vec :
        IFunction<object, object>
    {
        public object Invoke(object coll) =>
            coll == null
                ? Collections.Vector.EMPTY
                : coll is ISeq s ? Collections.Vector.Create(s)
                : coll is System.Collections.IEnumerable e ? Collections.Vector.Create(e)
                : Collections.Vector.Create(new ToArray().Invoke(coll));
    }
}
