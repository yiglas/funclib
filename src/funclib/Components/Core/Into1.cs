using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    class Into1 :
        IFunction<object, object, object>
    {
        public object Invoke(object to, object from) =>
            to is IEditableCollection
                ? funclib.Core.Persistentǃ(funclib.Core.Reduce1(funclib.Core.conjǃ, funclib.Core.Transient(to), from))
                : funclib.Core.Reduce1(funclib.Core.conj, to, from);
    }
}
