using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ZipMap :
        IFunction<object, object, object>
    {
        public object Invoke(object keys, object vals)
        {
            return loop(new HashMap().Invoke(), (ISeq)new Seq().Invoke(keys), (ISeq)new Seq().Invoke(vals));

            object loop(object map, ISeq ks, ISeq vs)
            {
                if ((bool)new Truthy().Invoke(new And().Invoke(ks, vs)))
                {
                    return loop(new Assoc().Invoke(map, ks.First(), vs.First()), ks.Next(), vs.Next());
                }

                return map;
            }
        }
    }
}
