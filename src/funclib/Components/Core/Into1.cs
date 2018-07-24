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
            to is IEditableCollection
                ? persistentǃ(reduce1(funclib.Core.Conjǃ, transient(to), from))
                : reduce1(funclib.Core.Conj, to, from);
    }
}
