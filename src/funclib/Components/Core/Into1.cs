using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    class Into1 :
        IFunction<object, object, object>
    {
        public object Invoke(object to, object from) =>
            to is IEditableCollection e
                ? persistentǃ(reduce1(new Conjǃ(), new Transient().Invoke(to), from))
                : reduce1(new Conj(), to, from);
    }
}
