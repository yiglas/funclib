using FunctionalLibrary.Collections;
using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Keys :
        IFunction<object, ISeq>
    {
        public ISeq Invoke(object coll)
        {
            if (coll is IMap map)
                return KeySeq.Create(map);

            return KeySeq.Create(new Seq().Invoke(coll));
        }
    }
}
