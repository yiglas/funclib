using FunctionalLibrary.Collections;
using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Keys :
        IFunction<object, object>
    {
        public object Invoke(object coll)
        {
            if (coll is IMap map)
                return KeySeq.Create(map);

            return KeySeq.Create((ISeq)new Seq().Invoke(coll));
        }
    }
}
