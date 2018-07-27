using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    class Into1 :
        IFunction<object, object, object>
    {
        public object Invoke(object to, object from) =>
            to is IEditableCollection
                ? persistentǃ(reduce1(funclib.core.Conjǃ, transient(to), from))
                : reduce1(funclib.core.Conj, to, from);
    }
}
