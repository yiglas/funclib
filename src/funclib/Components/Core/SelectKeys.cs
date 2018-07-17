using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class SelectKeys :
        IFunction<object, object, object>
    {
        public object Invoke(object map, object keyseq)
        {
            return loop(new HashMap().Invoke(), (ISeq)new Seq().Invoke(keyseq));

            object loop(object ret, ISeq keys)
            {
                if ((bool)new Truthy().Invoke(keys))
                {
                    var entry = new Find().Invoke(map, keys.First());
                    return loop((bool)new Truthy().Invoke(entry) ? new Conj().Invoke(ret, entry) : ret, keys.Next());
                }

                return ret;
            }
        }
    }
}
